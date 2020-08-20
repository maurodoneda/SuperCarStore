using SuperCarStore.Data;
using SuperCarStore.ViewModels;
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

            var stores = new StoresViewModel
            {
                SelectedStoreId = 0,
                Stores = db.Stores.ToList(),
                Cars = db.Cars.ToList()
            };



            return View(stores);
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

            var stores = db.Stores.ToList();
                        
            return View(stores);
        }


        public ActionResult BookCar()
        {
          

                return View();
        }
    }
}