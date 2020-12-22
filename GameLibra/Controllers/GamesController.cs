using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameLibra.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GameLibra.Controllers
{
    /*
     * Idea from developersController
     if (User.IsInRole(RoleName.CanManageEverything))//get from db, name of the role
            {
                return View("Index",await db.Developers.OrderBy(g => g.Name).ToListAsync());
            }
            else {
                return View("ReadOnlyList", await db.Developers.OrderBy(g => g.Name).ToListAsync());
            }
     */
    [Authorize(Roles = "CanManageEverything")]
    public class GamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Games
        public async Task<ActionResult> Index()
        {
            var games = db.Games.Include(g => g.Developer).Include(g => g.Publisher);
            return View(await games.ToListAsync());
        }

        //public async Task<ActionResult> List()
        //{
        //    var games = db.Games.OrderBy(g => g.Name);
        //    //.Include(g => g.GameGenres)

        //    //for lack of knowledge i do not know how to automatically include Genre item into a set
        //    //ViewBag.Genres = await db.GamesAndGenresSet.ToListAsync();
        //    return View(await games.ToListAsync());
        //}

        [AllowAnonymous]
        public async Task<ActionResult> List(string search_str)
        {
            var games = db.Games.OrderBy(g => g.Name);
            if (!String.IsNullOrEmpty(search_str))
            {
                games = games.Where(g => g.Name.Contains(search_str)).OrderBy(g => g.Name);
            }
            ViewBag.Pics = await db.GamesAndImagesSet.ToListAsync();
            //.Include(g => g.GameGenres)
            return View("List", await games.ToListAsync());
        }

        // GET: Games/Details/5

        [AllowAnonymous]
        public async Task<ActionResult> PublicDetails(int? id, string search_str)
        {
            if (id == null)
            {
                return View("~/Views/Shared/404.cshtml");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!String.IsNullOrEmpty(search_str))
            {
                return RedirectToAction("List", "Games", new { search_str = search_str });
            }

            //FindAsync(id)
            if ( await db.Games.FindAsync(id) == null) {
                return View("~/Views/Shared/404.cshtml");
            }
            Game game = await db.Games.Where(g => g.Id == id)
                .Include(g => g.Developer).Include(g => g.Publisher)
                .Include(g => g.GameGenres).Include(g => g.GameImages)
                .Include(g => g.GameTrailers)
                .FirstAsync();


            //This is poorly written part
            // The following part is dedicated to receiving information from isthereanydeal API and sending it to the view
            // To get info I need to use async method. But, since this method is already async method, calling another async method casuing a problem
            // It simply gets the data too late. Probably, there is a way to make something better then implementing method inside another one.
            // But I cant bother with it right now, to little time on my hands.

            Models.ApiObject game_offers_info = new ApiObject();
            string GameNameTrimmed = game.getNameWithoutSpaces();
            string path = "https://api.isthereanydeal.com/v01/game/prices/?key=bfec8ca9256725997a38fcd84b3bfbe3367d2312&region=us&plains=" + GameNameTrimmed;
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                //Models.ApiObject values =  Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ApiObject>(result);
                Newtonsoft.Json.Linq.JObject o = Newtonsoft.Json.Linq.JObject.Parse(result);
                game_offers_info = new Models.ApiObject(Newtonsoft.Json.Linq.JObject.Parse(result), GameNameTrimmed);
            }

            //This part is switched off due to causing problems, that is mentioned in the upper comment.
            /*
            Models.ApiObject game_offers_info = new Models.ApiObject();
            GetApiObject(game_offers_info, game.getNameWithoutSpaces());*/
            if (game_offers_info.shop_infos != null)
            {
                ViewBag.game_offers_list = game_offers_info.GetTop4Offers();
            }
            else {
                ViewBag.game_offers_list = null;
            }
            

            //checking for errors
            if (game == null)
            {
                return View("~/Views/Shared/404.cshtml");
            }

            //Including Genres
            foreach (var item in game.GameGenres)
            {
                item.Genre = db.Genres.Where(i => i.Id == item.GenreId).FirstOrDefault();
            }


            return View(game);
        }


        //Cuurently not so useful method.
        public async void GetApiObject(Models.ApiObject game_info, string GameNameTrimmed)
        {
            //?pretty
            string path = "https://api.isthereanydeal.com/v01/game/prices/?key=bfec8ca9256725997a38fcd84b3bfbe3367d2312&country=UK&plains=" + GameNameTrimmed;
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                //Models.ApiObject values =  Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ApiObject>(result);
                Newtonsoft.Json.Linq.JObject o = Newtonsoft.Json.Linq.JObject.Parse(result);
                game_info = new Models.ApiObject(Newtonsoft.Json.Linq.JObject.Parse(result), GameNameTrimmed);
                return;
            }

            game_info = null;
        }

        // GET: Games/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //FindAsync(id)
            Game game = await db.Games.Where(g => g.Id == id)
                .Include(g => g.Developer).Include(g => g.Publisher)
                .Include(g => g.GameGenres).Include(g => g.GameImages)
                .Include(g => g.GameTrailers)
                .FirstAsync();
            if (game == null)
            {
                return HttpNotFound();
            }
            foreach (var item in game.GameGenres)
            {
                item.Genre = db.Genres.Where(i => i.Id == item.GenreId).FirstOrDefault();
            }

            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.DeveloperId = new SelectList(db.Developers, "Id", "Name");
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Release_date,Desription,DeveloperId,PublisherId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DeveloperId = new SelectList(db.Developers, "Id", "Name", game.DeveloperId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", game.PublisherId);
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeveloperId = new SelectList(db.Developers, "Id", "Name", game.DeveloperId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", game.PublisherId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Release_date,Desription,DeveloperId,PublisherId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DeveloperId = new SelectList(db.Developers, "Id", "Name", game.DeveloperId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", game.PublisherId);
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Game game = await db.Games.FindAsync(id);
            db.Games.Remove(game);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
