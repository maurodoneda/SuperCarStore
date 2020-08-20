using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SuperCarStore.Data;
using SuperCarStore.Models;
using System.IO;
using SuperCarStore.ViewModels;

namespace SuperCarStore.Controllers
{
    public class CarsController : Controller
    {
        private SuperCarStoreContext db = new SuperCarStoreContext();

        

    // GET: Cars
    public ActionResult Index(int? id, string searchString, string store)
        {

            List<string> storeList = new List<string>();

            var storeQuery = db.Stores.Select(x => x.City);
                             //from s in db.Stores 
                             //where (id == s.StoreId)
                             //select s;
            
            storeList.AddRange(storeQuery.Distinct());
            ViewBag.Store = new SelectList(storeList);


            //Query cars from db based on the input received

            var allCars = db.Cars.ToList();
            var carsInStore = db.Cars.Where(c => c.StoreId == id);

            
            //Controw flow for what should be displayed on the view

            if (!string.IsNullOrEmpty(store) && string.IsNullOrEmpty(searchString))
            {
                allCars = allCars.Where(x => x.Store.City.Equals(store)).ToList();
                return View(allCars);
            }

            else if(!string.IsNullOrEmpty(store) && !string.IsNullOrEmpty(searchString))
            {
                allCars = allCars.Where(x => x.Store.City.Equals(store)).ToList();
                var carsQuery = allCars.Where(x => x.Make.ToLower().Contains(searchString.ToLower())).ToList();
                return View(carsQuery);
            }

            if (!string.IsNullOrEmpty(searchString) && id == null)
            {
                allCars = allCars.Where(x => x.Make.ToLower().Contains(searchString.ToLower())).ToList();
                return View(allCars);
            } 
            else if(!string.IsNullOrEmpty(searchString) && id != null)
            {

                carsInStore = carsInStore.Where(x => x.Make.ToLower().Contains(searchString.ToLower()));
                return View(carsInStore);
            }

            if (id == null && searchString == null)
            {
                return View(allCars);
            }




            return View(carsInStore);
            
            
            //Select(x => x.StoreId == storeId);

            /*  */  /*Where(x => x.StoreId == storeId)*/


        }

        // GET: Cars/CarsInStore/1
        public ActionResult CarsInStore(StoresViewModel store)
        {

       
            int storeId = store.SelectedStoreId;

            return RedirectToAction("Index", new {id = storeId} );

            //return Index(id);
        }



        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Make,Model,Year,HP,EngineSpec,FuelType,TopSpeed,ZeroTo60,SalePrice,RentalPrice,ImgUrl,StoreId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Make,Model,Year,HP,EngineSpec,FuelType,TopSpeed,ZeroTo60,SalePrice,RentalPrice,ImgUrl,StoreId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
