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
using Microsoft.AspNet.Identity;

namespace GameLibra.Controllers
{
    public class Games_and_LibrariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Games_and_Libraries
        [Authorize(Roles = "CanManageEverything")]
        public async Task<ActionResult> Index()
        {
            var gamesAndLibrariesSet = db.GamesAndLibrariesSet.Include(g => g.Game).Include(g => g.Library);
            return View(await gamesAndLibrariesSet.ToListAsync());
        }

        // GET: Games_and_Libraries/Details/5
        [Authorize(Roles = "CanManageEverything")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games_and_Libraries games_and_Libraries = await db.GamesAndLibrariesSet.FindAsync(id);
            if (games_and_Libraries == null)
            {
                return HttpNotFound();
            }
            return View(games_and_Libraries);
        }

        // GET: Games_and_Libraries/Create
        [Authorize(Roles = "CanManageEverything")]
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name");
            ViewBag.LibraryId = new SelectList(db.Libraries, "Id", "Name");
            return View();
        }

        // POST: Games_and_Libraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "CanManageEverything")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,GameId,LibraryId")] Games_and_Libraries games_and_Libraries)
        {
            if (ModelState.IsValid)
            {
                db.GamesAndLibrariesSet.Add(games_and_Libraries);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", games_and_Libraries.GameId);
            ViewBag.LibraryId = new SelectList(db.Libraries, "Id", "Name", games_and_Libraries.LibraryId);
            return View(games_and_Libraries);
        }

        [Authorize]
        public ActionResult AddGameToLibrary(int? gameId)
        {
            if (gameId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(gameId);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = game;
            var user = User.Identity.GetUserId();

            ViewBag.LibraryId = new SelectList(db.Libraries
                .Where(lib => lib.ApplicationUserId.Equals(user)), "Id", "Name");
            return View("AddGameToLibrary");
        }
        // POST: Games_and_Libraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddGameToLibrary([Bind(Include = "Id,GameId,LibraryId")] Games_and_Libraries games_and_Libraries)
        {
            if (ModelState.IsValid)
            {
                if (db.GamesAndLibrariesSet.Where(g => g.GameId.Equals(games_and_Libraries.GameId) 
                && g.LibraryId.Equals(games_and_Libraries.LibraryId) ).Count() == 0)
                {
                    db.GamesAndLibrariesSet.Add(games_and_Libraries);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Details", "Libraries", new { id = games_and_Libraries.LibraryId });
            }

            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", games_and_Libraries.GameId);
            ViewBag.LibraryId = new SelectList(db.Libraries, "Id", "Name", games_and_Libraries.LibraryId);
            return View("~/Views/Shared/404.cshtml");
        }


        // GET: Games_and_Libraries/Edit/5
        [Authorize(Roles = "CanManageEverything")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games_and_Libraries games_and_Libraries = await db.GamesAndLibrariesSet.FindAsync(id);
            if (games_and_Libraries == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", games_and_Libraries.GameId);
            ViewBag.LibraryId = new SelectList(db.Libraries, "Id", "Name", games_and_Libraries.LibraryId);
            return View(games_and_Libraries);
        }

        // POST: Games_and_Libraries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "CanManageEverything")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,GameId,LibraryId")] Games_and_Libraries games_and_Libraries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(games_and_Libraries).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Name", games_and_Libraries.GameId);
            ViewBag.LibraryId = new SelectList(db.Libraries, "Id", "Name", games_and_Libraries.LibraryId);
            return View(games_and_Libraries);
        }

        // GET: Games_and_Libraries/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Games_and_Libraries games_and_Libraries = await db.GamesAndLibrariesSet.FindAsync(id);
            if (games_and_Libraries == null)
            {
                return HttpNotFound();
            }

            int libraryId = games_and_Libraries.LibraryId;
            db.GamesAndLibrariesSet.Remove(games_and_Libraries);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "Libraries", new { id = libraryId });
            //return View(games_and_Libraries);
        }

        // POST: Games_and_Libraries/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Games_and_Libraries games_and_Libraries = await db.GamesAndLibrariesSet.FindAsync(id);
            db.GamesAndLibrariesSet.Remove(games_and_Libraries);
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
