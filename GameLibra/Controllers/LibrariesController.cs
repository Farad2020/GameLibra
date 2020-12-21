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
    [Authorize]
    public class LibrariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Libraries
        public async Task<ActionResult> Index()
        {
            return View(await db.Libraries.OrderBy(l => l.Name).ToListAsync());
        }

        public async Task<ActionResult> List()
        {
            var userId = User.Identity.GetUserId();
            var libraries = await db.Libraries.OrderBy(l => l.Name).Where(lib => lib.ApplicationUserId.Equals(userId)).ToListAsync();
            return View(libraries);
        }

        // GET: Libraries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = await db.Libraries.FindAsync(id);


            ViewBag.LibraryGames = db.GamesAndLibrariesSet
                .Where(gal => gal.LibraryId.Equals(library.Id))
                .Include(gal => gal.Game).ToList();
            //ViewBag.GameId = new SelectList(db.Games, "Id", "Name");
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // GET: Libraries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Desription,Creation_date")] Library library)
        {
            if (ModelState.IsValid)
            {

                var user = User.Identity.GetUserId();
                library.ApplicationUserId = user;
                library.ApplicationUser = db.Users.Find(user);
                ////////////////////////// Check if works correctly
                library.Creation_date = DateTime.Now;
                db.Libraries.Add(library);
                await db.SaveChangesAsync();
                return RedirectToAction("List");
            }

            return View(library);
        }

        // GET: Libraries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = await db.Libraries.FindAsync(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // POST: Libraries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Desription,Creation_date")] Library library)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserId();
                library.ApplicationUserId = user;
                db.Entry(library).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return View(library);
        }

        // GET: Libraries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = await db.Libraries.FindAsync(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // POST: Libraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Library library = await db.Libraries.FindAsync(id);
            db.Libraries.Remove(library);
            await db.SaveChangesAsync();
            return RedirectToAction("List");
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
