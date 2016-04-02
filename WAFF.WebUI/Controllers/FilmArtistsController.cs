using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WAFF.DataAccess.Contexts;
using WAFF.DataAccess.Entity;

namespace WAFF.WebUI.Controllers
{
    public class FilmArtistsController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: FilmArtists
        public ActionResult Index()
        {
            return View(db.FilmArtists.ToList());
        }

        // GET: FilmArtists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmArtists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmID,ArtistID")] FilmArtist filmArtist)
        {
            if (ModelState.IsValid)
            {
                db.FilmArtists.Add(filmArtist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filmArtist);
        }

        // GET: FilmArtists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmArtist filmArtist = db.FilmArtists.Find(id);
            if (filmArtist == null)
            {
                return HttpNotFound();
            }
            return View(filmArtist);
        }

        // POST: FilmArtists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmID,ArtistID")] FilmArtist filmArtist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filmArtist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filmArtist);
        }

        // GET: FilmArtists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmArtist filmArtist = db.FilmArtists.Find(id);
            if (filmArtist == null)
            {
                return HttpNotFound();
            }
            return View(filmArtist);
        }

        // POST: FilmArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FilmArtist filmArtist = db.FilmArtists.Find(id);
            db.FilmArtists.Remove(filmArtist);
            db.SaveChanges();
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
