using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITTNetSoc.Models;
using PagedList;

namespace ITTNetSoc.Controllers
{
    public class GalleryController : Controller
    {
        private CompSocEntities DB = HomeController.newsDB;

        public ActionResult Index(int? page)
        {
            var pageIndex = page ?? 1;
            var pageSize = 5;
            var pageOfNews = DB.Albums.OrderByDescending(a => a.Id).ToPagedList(pageIndex, pageSize);
            ViewBag.pageOfAlbums = pageOfNews;
            return View(pageOfNews);
            /*
            ViewBag.Message = "Index";
           // var albums = DB.Albums.ToList();
            var albums = DB.Albums.ToList();
            return View(albums);*/
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AddAlbum()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult AddAlbum(CreateAlbumModel model)
        {
            if (ModelState.IsValid)
            {
                // Add the album
                //TEST PICTURES
                Album temp = new Album
                 {
                     Id = 1,
                     AlbumName = model.AlbumName,
                     Description = model.Description,
                     time = System.DateTime.Now.TimeOfDay.ToString(),
                     date = System.DateTime.Today.Date.ToString()
                 };

                HomeController.newsDB.Albums.Add(temp);
                HomeController.newsDB.SaveChanges();
                //Successful
                return RedirectToAction("AlbumDetail", HomeController.newsDB.Albums.Find(temp.Id));
            }
            else
            {
                //Error
                return View(model);
            }
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteAlbum(int id)
        {
            Album a = HomeController.newsDB.Albums.Find(id);
            return View(a);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("DeleteAlbum")]
        public ActionResult DeleteConfirmed(int id)
        {
            Album a = HomeController.newsDB.Albums.Find(id);
            HomeController.newsDB.Albums.Remove(a);

            //Removing pictures from that album
            foreach (Picture pic in PictureFromAlbum(id))
            {
                string filePath = Server.MapPath(pic.Source);
                System.IO.File.Delete(filePath);
                HomeController.newsDB.Pictures.Remove(pic);
            }

            HomeController.newsDB.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult EditAlbum(int id)
        {
            Album a = HomeController.newsDB.Albums.Find(id);
            ((IObjectContextAdapter)HomeController.newsDB).ObjectContext.Detach(a); // Had to detach, was receiving
            // Entity Framework errors.
            return View(a);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult EditAlbum(Album editAlbum)
        {
            if (ModelState.IsValid)
            {
                HomeController.newsDB.Entry(editAlbum).State = EntityState.Modified;
                HomeController.newsDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editAlbum);
        }

        public ActionResult AlbumDetail(int id)
        {
            //error handling
            if (DB.Albums.Find(id) != null)
            {
                if (DB.comments.SqlQuery("select * from comments where commentType='Gallery' AND itemID=" + id).Count() < 1)
                {
                    var userComments = "No Comments";
                    ViewBag.userComments = userComments;
                }
                else
                {
                    var userComments = DB.comments.SqlQuery("select * from comments where commentType='Gallery' AND itemID=" + id).ToList().OrderBy(c => c.commentID);
                    ViewBag.userComments = userComments;
                }
                return View(DB.Albums.Find(id));
            }
            else
            {
                return RedirectToAction("Index"); //If it doesn't exist, go here.
            }
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AddPictures(Album a)
        {
            return View(a);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult AddPictures(int ID, IEnumerable<HttpPostedFileBase> AddPics)
        {
            foreach (var pic in AddPics)
            {
                //Check if image
                try
                {
                    var tempImage = Bitmap.FromStream(pic.InputStream); //This will throw an exception if not real

                    //Create a GUID for a file name. Each picture name will be unique
                    Guid pictureName = Guid.NewGuid();
                    string filePath = Server.MapPath("\\PICTURES\\") + pictureName.ToString() + Path.GetExtension(pic.FileName);

                    pic.SaveAs(filePath);

                    //Create a new Picture object now
                    Picture pix = new Picture
                    {
                        Source = "/PICTURES/" + pictureName.ToString() + Path.GetExtension(pic.FileName),
                        AlbumId = ID
                    };
                    HomeController.newsDB.Pictures.Add(pix);
                }
                catch (Exception e)
                {
                    //not a real image
                }
            }
            HomeController.newsDB.SaveChanges();
            // AlbumDetail(ID);
            // return View("AlbumDetail", new { id = ID });
            //return PartialView("AlbumDetail", new { id = ID });
            // return null;
            //return RedirectToAction("AlbumDetail", new { id = ID });
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult DeletePicture(int Id)
        {
            return View(HomeController.newsDB.Pictures.Find(Id));
        }

        [Authorize(Roles = "Administrator")]
        [ActionName("DeleteAlbumPicture")]
        public ActionResult DeleteConfirmedPicture(Picture pic)
        {
            int albumId = pic.AlbumId;
            HomeController.newsDB.Pictures.Remove(HomeController.newsDB.Pictures.Find(pic.Id));
            HomeController.newsDB.SaveChanges();
            return RedirectToAction("EditAlbum/" + albumId); //Return to editing
        }

        public static Picture Picture(int id)
        {
            var pic = HomeController.newsDB.Pictures.Find(id);
            return pic;
        }

        public static List<Picture> PictureFromAlbum(int albumId)
        {
            List<Picture> pics = new List<Picture>();

            //Return all the pics with the AlbumID matching the albumID
            foreach (Picture p in HomeController.newsDB.Pictures.ToList())
            {
                if (p.AlbumId == albumId)
                {
                    pics.Add(p);
                }
            }
            return pics;
        }
    }
}