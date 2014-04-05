using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ITTNetSoc.Models;

namespace ITTNetSoc.Controllers
{
    public class UserProfileController : Controller
    {
        private CompSocEntities db = new CompSocEntities();

        //
        // GET: /UserProfile/

        public ViewResult Index()
        {
            return View(db.UserProfiles.ToList());
        }

        public ViewResult Details(int Id = -1) //Optional parameter.
        {
            UserProfile userprofile = null;
            if (Id == -1) //If no user was specified, then go to user logged in.
            {
                if (Membership.GetUser() == null) //no one logged in. Show index.
                {
                    return View("~/Views/UserProfile/M/Index.cshtml", db.UserProfiles.ToList());
                }
                Guid userId = (Guid)Membership.GetUser().ProviderUserKey;

                foreach (UserProfile u in db.UserProfiles.ToList())
                {
                    if (u.AccountId != null)
                    {
                        if (u.AccountId == userId.ToString())
                        {
                            userprofile = u;
                            break;
                        }
                    }
                }
                if (userprofile == null && userId != null)
                {
                    //create a userprofile for this user.
                    userprofile = new UserProfile();
                    userprofile.AccountId = userId.ToString();
                    userprofile.Question = Membership.GetUser(userId).PasswordQuestion;
                    userprofile.Answer = "";
                    userprofile.Description = "Descripion here";
                    userprofile.Department = "Department here";
                    userprofile.DisplayName = Membership.GetUser(userId).UserName;
                    userprofile.Picture = "Unknown.jpg";
                    userprofile.Year = 0;
                    db.UserProfiles.Add(userprofile);
                    db.SaveChanges();
                }
            }
            else
            {
                userprofile = db.UserProfiles.Find(Id);
            }
            return View(userprofile);
        }

        //
        // GET: /UserProfile/Edit/5
        public ActionResult Edit()
        {
            if (Membership.GetUser() != null) //if logged in
            {
                Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
                UserProfile userprofile = null;
                foreach (UserProfile u in db.UserProfiles.ToList())
                {
                    if (u.AccountId != null)
                    {
                        if (u.AccountId == userId.ToString())
                        {
                            userprofile = u;
                            break;
                        }
                    }
                }
                if (userprofile == null && userId != null)
                {
                    //create a userprofile for this user.
                    userprofile = new UserProfile();
                    userprofile.AccountId = userId.ToString();
                    userprofile.Question = Membership.GetUser(userId).PasswordQuestion;
                    userprofile.Answer = "";
                    userprofile.Description = "Descripion here";
                    userprofile.Department = "Department here";
                    userprofile.DisplayName = Membership.GetUser(userId).UserName;
                    userprofile.Picture = "Unknown.jpg";
                    userprofile.Year = 0;
                    db.UserProfiles.Add(userprofile);
                    db.SaveChanges();
                }
                return View(userprofile);
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //
        // POST: /UserProfile/Edit/5

        [HttpPost]
        public ActionResult Edit(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                //string filePath = Server.MapPath("\\PICTURES\\") + Path.GetFileName(userprofile.PictureUpload.FileName);
                ////   System.IO.File.Create(filePath);
                //userprofile.PictureUpload.SaveAs(filePath);
                //userprofile.Picture = userprofile.PictureUpload.FileName;
                db.Entry(userprofile).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(userprofile);
        }

        public ActionResult ChangeProfilePicture(int id)
        {
            //Check to make sure the user is infact the logged in user.
            if (db.UserProfiles.Find(id).AccountId.Equals(Membership.GetUser().ProviderUserKey.ToString()))
            {
                //Correct user
                return View(db.UserProfiles.Find(id));
            }
            //If it came to this, then the user logged in isn't the user who should be changing this users profile picture
            return RedirectToAction("Index", "UserProfile");
        }

        [HttpPost]
        public ActionResult ChangeProfilePicture(int ID, HttpPostedFileBase ProfilePicture)
        {
            //Check if image
            try
            {
                var tempImage = Bitmap.FromStream(ProfilePicture.InputStream); //This will throw an exception if not real image

                string filePath = Server.MapPath("\\PICTURES\\") + db.UserProfiles.Find(ID).AccountId + Path.GetExtension(ProfilePicture.FileName);
                //System.IO.File.Delete(Server.MapPath("\\PICTURES\\") + db.UserProfiles.Find(ID).Picture);

                ProfilePicture.SaveAs(filePath);
                db.UserProfiles.Find(ID).Picture = filePath.Split('\\')[filePath.Split('\\').Length - 1];
                db.SaveChanges();
            }
            catch (Exception e)
            {
                //not a real image
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}