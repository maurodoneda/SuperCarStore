using SuperCarStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperCarStore.Controllers
{
    public class HomeController : Controller
    {
        private SuperCarStoreContext db = new SuperCarStoreContext();
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

        public ActionResult Stores()
        {
            ViewBag.Message = "Check out our Stores around the world";
                        
            return View(db.Stores.ToList());
        }
    }
}