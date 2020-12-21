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
    public class Games_and_TrailersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Games_and_Trailers
        public async Task<ActionResult> Index()
        {
            var gamesAndTrailersSet = db.GamesAndTrailersSet.Include(g => g.Game).OrderBy(g => g.Game.Name);
            return View(await gamesAndTrailersSet.ToListAsync());
        }

        // GET: Games_and_Trailers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games_and_Trailers games_and_Trailers = await db.GamesAndTrailersSet.FindAsync(id);
            if (games_and_Trailers == null)
            {
                return HttpNotFound();
            }
            return View(games_and_Trailers);
        }

        // GET: Games_and_Trailers/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games.OrderBy(g => g.Name), "Id", "Name");
            return View();
        }

        // POST: Games_and_Trailers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,GameId,Link")] Games_and_Trailers games_and_Trailers)
        {
            if (ModelState.IsValid)
            {
                db.GamesAndTrailersSet.Add(games_and_Trailers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", games_and_Trailers.GameId);
            return View(games_and_Trailers);
        }

        // GET: Games_and_Trailers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games_and_Trailers games_and_Trailers = await db.GamesAndTrailersSet.FindAsync(id);
            if (games_and_Trailers == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games.OrderBy(g => g.Name), "Id", "Name", games_and_Trailers.GameId);
            return View(games_and_Trailers);
        }

        // POST: Games_and_Trailers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,GameId,Link")] Games_and_Trailers games_and_Trailers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(games_and_Trailers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games.OrderBy(g => g.Name), "Id", "Name", games_and_Trailers.GameId);
            return View(games_and_Trailers);
        }

        // GET: Games_and_Trailers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games_and_Trailers games_and_Trailers = await db.GamesAndTrailersSet.FindAsync(id);
            if (games_and_Trailers == null)
            {
                return HttpNotFound();
            }
            return View(games_and_Trailers);
        }

        // POST: Games_and_Trailers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Games_and_Trailers games_and_Trailers = await db.GamesAndTrailersSet.FindAsync(id);
            db.GamesAndTrailersSet.Remove(games_and_Trailers);
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
