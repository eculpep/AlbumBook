using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlbumBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Album Book";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Album Book contact page.";

            return View();
        }
    }
}