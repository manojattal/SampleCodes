using eManager.Domain;
using eManager.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class HomeController : Controller
    {
        IDepartmentDataSource _db;

        public HomeController(DepartmentDb db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            return View(_db.Departments);
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

        public string SayHi()
        {
            return "Hi";
        }
    }
}
