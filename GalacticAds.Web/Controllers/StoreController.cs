﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalacticAds.Web.Models;
using GalacticAds.Web.Services;

namespace GalacticAds.Web.Controllers
{
    [Authorize]
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


        public ActionResult Summary(int id)
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
                return RedirectToAction("Details", new { id = newStore.Id });
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
                return RedirectToAction("Details", new { id = id });
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
