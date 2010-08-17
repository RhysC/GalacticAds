using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using GalacticAds.Web.Models;
using GalacticAds.Web.Services;

namespace GalacticAds.Web.Controllers
{
    public class StoreContractController : Controller
    {
        public ActionResult Details(int id, int contractId)
        {
            var store = Store.Find(id);
            var contract = store.Contracts.First(x => x.Id == contractId);
            return File(contract.Document, contract.DocumentMimeType, contract.DocumentFileName);
        }

        public ActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int id, StoreContract contract)
        {
            var store = Store.Find(id);
            if (store == null) throw new InvalidOperationException("no store found");
            //var contract = new StoreContract();
            //TryUpdateModel(contract);
            contract.CreateAndFlush();
            store.AddContract(contract);
            //DateTime startDate = DateTime.Parse(collection["StartDate"]);
            //decimal agreedPricePerNonPrintedRoll = decimal.Parse(collection["AgreedPricePerNonPrintedRoll"]);
            //var contract = store.AddContract(startDate, agreedPricePerNonPrintedRoll);
            //http://www.mikesdotnetting.com/Article/125/ASP.NET-MVC-Uploading-and-Downloading-Files
            if (Request.Files.Count > 0 && Request.Files[0].HasFile())
            {
                var httpFile = Request.Files[0];
                string mimeType = httpFile.ContentType;
                Stream fileStream = httpFile.InputStream;
                string fileName = Path.GetFileName(httpFile.FileName);
                int fileLength = httpFile.ContentLength;
                byte[] fileData = new byte[fileLength];
                fileStream.Read(fileData, 0, fileLength);
                contract.AddDocument(fileName, mimeType, fileData);
            }
            store.SaveAndFlush();
            return View();
        }


        //
        // GET: /StoreContract/

        public ActionResult Index(int id)
        {
            return View();
        }
        
        //
        // GET: /StoreContract/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /StoreContract/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /StoreContract/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /StoreContract/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
