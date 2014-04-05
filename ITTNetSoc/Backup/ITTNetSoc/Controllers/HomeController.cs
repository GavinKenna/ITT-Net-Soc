using System.Linq;
using System.Web.Mvc;
using ITTNetSoc.Models;

namespace ITTNetSoc.Controllers
{
    public class HomeController : Controller
    {
        public static CompSocEntities newsDB = new CompSocEntities();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the ITT CompSoc Website";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult Error()
        {
            ViewBag.Message = "Error";
            return View();
        }
    }
}