using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRancor.Controllers
{
    //This represents the homepage. This view, ideally, will be something like a news feed, where the latest reviews, or a hot one with many active recent comments will be here. 
    //Also, there could be stuff like announcements from the admins or featured lists or whatever.
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}