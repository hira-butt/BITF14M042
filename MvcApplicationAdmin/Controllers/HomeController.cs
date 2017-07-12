using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationAdmin.Models;

namespace MvcApplicationAdmin.Controllers
{
    public class HomeController : Controller
    {

        Database1Entities db = new Database1Entities();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Staff()
        {
            return View();
        }

        public ActionResult Student()
        {
            return View();
        }

    }
}
