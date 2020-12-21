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
    public class Games_and_ImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Games_and_Images
        public async Task<ActionResult> Index()
        {
            var gamesAndImagesSet = db.GamesAndImagesSet.Include(g => g.Game).OrderBy(g => g.Game.Name);
            return View(await gamesAndImagesSet.ToListAsync());
        }

        // GET: Games_and_Images/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games_and_Images games_and_Images = await db.GamesAndImagesSet.FindAsync(id);
            if (games_and_Images == null)
            {
                return HttpNotFound();
            }
            return View(games_and_Images);
        }

        // GET: Games_and_Images/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games.OrderBy(g => g.Name), "Id", "Name");
            return View();
        }

        // POST: Games_and_Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,GameId,Link")] Games_and_Images games_and_Images)
        {
            if (ModelState.IsValid)
            {
                db.GamesAndImagesSet.Add(games_and_Images);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games.OrderBy(g => g.Name), "Id", "Name", games_and_Images.GameId);
            return View(games_and_Images);
        }

        // GET: Games_and_Images/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games_and_Images games_and_Images = await db.GamesAndImagesSet.FindAsync(id);
            if (games_and_Images == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games.OrderBy(g => g.Name), "Id", "Name", games_and_Images.GameId);
            return View(games_and_Images);
        }

        // POST: Games_and_Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,GameId,Link")] Games_and_Images games_and_Images)
        {
            if (ModelState.IsValid)
            {
                db.Entry(games_and_Images).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games.OrderBy(g => g.Name), "Id", "Name", games_and_Images.GameId);
            return View(games_and_Images);
        }

        // GET: Games_and_Images/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games_and_Images games_and_Images = await db.GamesAndImagesSet.FindAsync(id);
            if (games_and_Images == null)
            {
                return HttpNotFound();
            }
            return View(games_and_Images);
        }

        // POST: Games_and_Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Games_and_Images games_and_Images = await db.GamesAndImagesSet.FindAsync(id);
            db.GamesAndImagesSet.Remove(games_and_Images);
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
