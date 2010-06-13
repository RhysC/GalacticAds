using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalacticAds.Web.Models;

namespace GalacticAds.Web.Controllers
{
    public class StoreController : Controller
    {
        public ActionResult Index()
        {
            var stores = Store.FindAll();
            return View(stores);
        }

        public ActionResult Details(int id)
        {
            return View(Store.Find(id));
        }

        public ActionResult Map(int id)
        {
            return View(Store.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Store newStore)
        {
            try
            {
                LocationService.SetGeographicalLocation(newStore.GeographicalLocation);
                newStore.CreateAndFlush();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ex.ToString();
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(Store.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var existingStore = Store.Find(id);
                TryUpdateModel(existingStore);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(Store.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var existingStore = Store.Find(id);
                existingStore.DeleteAndFlush();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
