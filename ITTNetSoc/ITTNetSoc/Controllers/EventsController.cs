using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ITTNetSoc.Models;
using PagedList;

namespace ITTNetSoc.Controllers
{
    public class EventsController : Controller
    {
        private CompSocEntities db = new CompSocEntities();

        //
        // GET: /Events/

        public ViewResult Index(int? page)
        {
            var pageIndex = page ?? 1;
            var pageSize = 5;
            var pageOfEvents = db.Events.OrderByDescending(e => e.Id).ToPagedList(pageIndex, pageSize);
            ViewBag.pageOfEvents = pageOfEvents;
            return View();
        }

        //
        // GET: /Events/Details/5

        public ActionResult Details(int id)
        {
            //Error handling
            if (db.Events.Find(id) != null)
            {
                Event events = db.Events.Find(id);

                if (db.comments.SqlQuery("select * from comments where commentType='Events' AND itemID=" + id).Count() < 1)
                {
                    var userComments = "No Comments";
                    ViewBag.userComments = userComments;
                }
                else
                {
                    var userComments = db.comments.SqlQuery("select * from comments where commentType='Events' AND itemID=" + id).ToList().OrderBy(c => c.commentID);
                    ViewBag.userComments = userComments;
                }
                return View(events);
            }
            else
            {
                return RedirectToAction("Index"); //If it doesn't exist, go here.
            }
        }

        //
        // GET: /Events/Create

        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Events/Create

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Create(Event events)
        {
            events.Author = db.GetUserFromMember(Membership.GetUser()).DisplayName;
            events.AuthorID = db.GetUserFromMember(Membership.GetUser()).Id;
            db.Events.Add(events);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Events/Edit/5

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            Event events = db.Events.Find(id);
            return View(events);
        }

        //
        // POST: /Events/Edit/5

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(Event events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(events);
        }

        //
        // GET: /Events/Delete/5

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            Event events = db.Events.Find(id);
            return View(events);
        }

        //
        // POST: /Events/Delete/5

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Event events = db.Events.Find(id);
            db.Events.Remove(events);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}