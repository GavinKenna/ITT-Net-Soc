using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ITTNetSoc.Models;
using PagedList;

namespace ITTNetSoc.Controllers
{
    public class NewsController : Controller
    {
        private CompSocEntities db = new CompSocEntities();

        //
        // GET: /News/

        public ViewResult Index(int? page)
        {
            var pageIndex = page ?? 1;
            var pageSize = 5;
            var pageOfNews = db.NewsItems.OrderByDescending(a => a.Id).ToPagedList(pageIndex, pageSize);
            ViewBag.pageOfNews = pageOfNews;
            return View();
        }

        //
        // GET: /News/Details/5

        public ActionResult Details(int id)
        {
            //Error handling
            if (db.NewsItems.Find(id) != null)
            {
                NewsItem newsitem = db.NewsItems.Find(id);

                if (db.comments.SqlQuery("select * from comments where commentType='News' AND itemID=" + id).Count() < 1)
                {
                    var userComments = "No Comments";
                    ViewBag.userComments = userComments;
                }
                else
                {
                    var userComments = db.comments.SqlQuery("select * from comments where commentType='News' AND itemID=" + id).ToList().OrderBy(c => c.commentID);
                    ViewBag.userComments = userComments;
                }
                return View(newsitem);
            }
            else
            {
                return RedirectToAction("Index"); //If it doesn't exist, go here.
            }
        }

        //
        // GET: /News/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /News/Create

        [HttpPost]
        public ActionResult Create(NewsItem newsitem)
        {
            //Set author to person logged in
            newsitem.Author = db.GetUserFromMember(Membership.GetUser()).DisplayName;
            newsitem.AuthorID = db.GetUserFromMember(Membership.GetUser()).Id;
            db.NewsItems.Add(newsitem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /News/Edit/5

        public ActionResult Edit(int id)
        {
            NewsItem newsitem = db.NewsItems.Find(id);
            return View(newsitem);
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        public ActionResult Edit(NewsItem newsitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsitem);
        }

        //
        // GET: /News/Delete/5

        public ActionResult Delete(int id)
        {
            NewsItem newsitem = db.NewsItems.Find(id);
            return View(newsitem);
        }

        //
        // POST: /News/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsItem newsitem = db.NewsItems.Find(id);
            db.NewsItems.Remove(newsitem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ViewResult SearchNews(int? page, string searchString)
        {
            var pageIndex = page ?? 1;
            var pageSize = 5;

            var news = from n in db.NewsItems
                       select n;

            if (!String.IsNullOrEmpty(searchString))
            {
                news = news.Where(n => n.Body.Contains(searchString)).OrderByDescending(n => n.Id);

                var pageOfResults = news.ToPagedList(pageIndex, pageSize);
                ViewBag.pageOfResults = pageOfResults;
                ViewBag.searchString = searchString;
            }

            return View();
        }
    }
}