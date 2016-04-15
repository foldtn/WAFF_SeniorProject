using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WAFF.DataAccess.Contexts;
using WAFF.DataAccess.Entity;
using WAFF.Services.Admin;

namespace WAFF.WebUI.Controllers
{
    public class EventsController : Controller
    {
        private readonly EFDbContext _db = new EFDbContext();
        private readonly AdminService _adminService = new AdminService();

        // GET: Events
        public ActionResult Index()
        {
            return View(_db.Events.ToList());
        }

        public ActionResult ManageEventFilms(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var model = _adminService.GetAdminEventViewModelById(id);

            return View(model);
        }

        public ActionResult EventManageList()
        {
            return View(_db.Events.ToList());
        }

        // GET: Events/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Event @event = _db.Events.Find(id);
        //    if (@event == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(@event);
        //}

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventStartDate,EventEndDate,EventLocation")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _db.Events.Add(@event);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventStartDate,EventEndDate,EventLocation")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(@event).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = _db.Events.Find(id);
            _db.Events.Remove(@event);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
