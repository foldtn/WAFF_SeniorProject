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
    public class FilmBlocksController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: FilmBlocks
        public ActionResult Index()
        {
            return View(db.FilmBlocks.ToList());
        }

        // GET: FilmBlocks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmBlocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmID,BlockID")] FilmBlock filmBlock)
        {
            if (ModelState.IsValid)
            {
                db.FilmBlocks.Add(filmBlock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filmBlock);
        }

        // GET: FilmBlocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmBlock filmBlock = db.FilmBlocks.Find(id);
            if (filmBlock == null)
            {
                return HttpNotFound();
            }
            return View(filmBlock);
        }

        // POST: FilmBlocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmID,BlockID")] FilmBlock filmBlock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filmBlock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filmBlock);
        }

        // GET: FilmBlocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmBlock filmBlock = db.FilmBlocks.Find(id);
            if (filmBlock == null)
            {
                return HttpNotFound();
            }
            return View(filmBlock);
        }

        // POST: FilmBlocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FilmBlock filmBlock = db.FilmBlocks.Find(id);
            db.FilmBlocks.Remove(filmBlock);
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
