using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalacticAds.Web.Models;
using NHibernate.Criterion;
using Castle.ActiveRecord.Queries;
using Castle.ActiveRecord;

namespace GalacticAds.Web.Controllers
{
    public class AdvertiserController : Controller
    {
        public ActionResult Index()
        {
            return View(Advertiser.FindAll());
        }

        public ActionResult Details(int id)
        {
            return View(Advertiser.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Advertiser newAdvertiser, FormCollection formCollection)
        {
            try
            {
                using (new SessionScope())
                {
                    AddCategories(newAdvertiser, formCollection);
                    LocationService.SetGeographicalLocation(newAdvertiser.GeographicalLocation);
                    newAdvertiser.CreateAndFlush();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var x = ex.ToString();
                return View();
            }
        }

        private static void AddCategories(Advertiser newAdvertiser, FormCollection formCollection)
        {
            var categoryIds = formCollection["Categories"].ToString().Split(',');
            foreach (var categoryId in categoryIds)
            {
                var category = Category.Find(int.Parse(categoryId));
                newAdvertiser.Categories.Add(category);
            }
        }

        public ActionResult Edit(int id)
        {
            return View(Advertiser.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var existingAdvertiser = Advertiser.Find(id);
                TryUpdateModel(existingAdvertiser);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(Advertiser.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var existingAdvertiser = Advertiser.Find(id);
                existingAdvertiser.DeleteAndFlush();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
