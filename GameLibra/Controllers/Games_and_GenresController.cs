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

namespace GameLibra.Controllers
{
    [Authorize(Roles = "CanManageEverything")]
    public class Games_and_GenresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Games_and_Genres
        public async Task<ActionResult> Index()
        {
            var gamesAndGenresSet = db.GamesAndGenresSet.Include(g => g.Game).Include(g => g.Genre).OrderBy(g => g.Game.Name);
            return View(await gamesAndGenresSet.ToListAsync());
        }

        // GET: Games_and_Genres/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games_and_Genres games_and_Genres = await db.GamesAndGenresSet.FindAsync(id);
            if (games_and_Genres == null)
            {
                return HttpNotFound();
            }
            return View(games_and_Genres);
        }

        // GET: Games_and_Genres/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games.OrderBy(g => g.Name), "Id", "Name");
            ViewBag.GenreId = new SelectList(db.Genres.OrderBy(g => g.Name), "Id", "Name");
            return View();
        }

        // POST: Games_and_Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,GameId,GenreId")] Games_and_Genres games_and_Genres)
        {
            if (ModelState.IsValid)
            {
                db.GamesAndGenresSet.Add(games_and_Genres);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games.OrderBy(g => g.Name), "Id", "Name", games_and_Genres.GameId);
            ViewBag.GenreId = new SelectList(db.Genres.OrderBy(g => g.Name), "Id", "Name", games_and_Genres.GenreId);
            return View(games_and_Genres);
        }

        // GET: Games_and_Genres/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games_and_Genres games_and_Genres = await db.GamesAndGenresSet.FindAsync(id);
            if (games_and_Genres == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games.OrderBy(g => g.Name), "Id", "Name", games_and_Genres.GameId);
            ViewBag.GenreId = new SelectList(db.Genres.OrderBy(g => g.Name), "Id", "Name", games_and_Genres.GenreId);
            return View(games_and_Genres);
        }

        // POST: Games_and_Genres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,GameId,GenreId")] Games_and_Genres games_and_Genres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(games_and_Genres).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games.OrderBy(g => g.Name), "Id", "Name", games_and_Genres.GameId);
            ViewBag.GenreId = new SelectList(db.Genres.OrderBy(g => g.Name), "Id", "Name", games_and_Genres.GenreId);
            return View(games_and_Genres);
        }

        // GET: Games_and_Genres/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games_and_Genres games_and_Genres = await db.GamesAndGenresSet.FindAsync(id);
            if (games_and_Genres == null)
            {
                return HttpNotFound();
            }
            return View(games_and_Genres);
        }

        // POST: Games_and_Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Games_and_Genres games_and_Genres = await db.GamesAndGenresSet.FindAsync(id);
            db.GamesAndGenresSet.Remove(games_and_Genres);
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
