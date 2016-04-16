﻿using System;
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
    [Authorize]
    public class BlocksController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: Blocks
        public ActionResult Index()
        {
            return View(db.Blocks.ToList());
        }

        // GET: Blocks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlockID,BlockStart,BlockEnd,BlockLocation,BlockType,EventID")] Block block)
        {
            if (ModelState.IsValid)
            {
                db.Blocks.Add(block);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(block);
        }

        // GET: Blocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Block block = db.Blocks.Find(id);
            if (block == null)
            {
                return HttpNotFound();
            }
            return View(block);
        }

        // POST: Blocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlockID,BlockStart,BlockEnd,BlockLocation,BlockType,EventID")] Block block)
        {
            if (ModelState.IsValid)
            {
                db.Entry(block).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(block);
        }

        // GET: Blocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Block block = db.Blocks.Find(id);
            if (block == null)
            {
                return HttpNotFound();
            }
            return View(block);
        }

        // POST: Blocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IEnumerable<FilmBlock> fb = db.FilmBlocks.Where(x => x.BlockID == id);
            db.FilmBlocks.RemoveRange(fb);

            db.SaveChanges();
            
            Block block = db.Blocks.Find(id);
            db.Blocks.Remove(block);
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
