using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ITTNetSoc.Models;

namespace ITTNetSoc.Controllers
{
    public class CommentController : Controller
    {
        private CompSocEntities db = new CompSocEntities();

        //
        // GET: /Default1/

        public ViewResult Index()
        {
            return View(db.comments.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ViewResult Details(int id)
        {
            Comments comments = db.comments.Find(id);
            return View(comments);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(Comments comments, int itemID, string commentType)
        {
            comments.author = db.GetUserFromMember(Membership.GetUser()).DisplayName;
            comments.AuthorID = db.GetUserFromMember(Membership.GetUser()).Id;
            comments.date = DateTime.Today.ToShortDateString();
            comments.time = DateTime.Now.ToLongTimeString();
            comments.commentType = commentType;
            comments.itemID = itemID;

            db.comments.Add(comments);
            db.SaveChanges();
            if (commentType.Equals("Gallery"))
            {
                return RedirectToAction("AlbumDetail", commentType, new { id = itemID }); //As gallery uses AlbumDetail instead of Details
            }
            return RedirectToAction("Details", commentType, new { id = itemID });
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id)
        {
            Comments comments = db.comments.Find(id);
            return View(comments);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(Comments comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comments);
        }

        //
        // GET: /Default1/Delete/5

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            Comments comments = db.comments.Find(id);
            return View(comments);
        }

        //
        // POST: /Default1/Delete/5

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, int itemID, string commentType)
        {
            Comments comments = db.comments.Find(id);
            db.comments.Remove(comments);
            db.SaveChanges();
            if (commentType.Equals("Gallery"))
            {
                return RedirectToAction("AlbumDetail", commentType, new { id = itemID }); //As gallery uses AlbumDetail instead of Details
            }
            return RedirectToAction("Details", commentType, new { id = itemID });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}