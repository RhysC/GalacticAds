using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Castle.ActiveRecord;
using MbUnit.Framework;
using GalacticAds.Web.Controllers;
using GalacticAds.Web.Models;
using System.Web.Routing;
using System.Web.Mvc;
using Rhino.Mocks;
using System.Web;

namespace GalacticAds.Web.Tests.Controllers
{
    [TestFixture]
    public class StoreContractControllerFixture
    {
        HttpContextMock contextMock;


        [SetUp]
        public void SetUp()
        {
            contextMock = new HttpContextMock();
            var files = Rhino.Mocks.MockRepository.GenerateMock<HttpFileCollectionBase>();
            files.Stub(x => x.Count).Return(0);
            contextMock.Request.Stub(x => x.Files).Return(files);
        }
        [Test]
        public void CanSaveNewContractWithoutADocument()
        {
            var store = new Store { Name = "store 1" };
            store.SaveAndFlush();
            var controller = new StoreContractController();
            controller.ControllerContext = new ControllerContext(contextMock.Context, new RouteData(), controller);
            var newContract = new StoreContract
            {
                StartDate = DateTime.Now.AddDays(-30),
                TermInMonths = 24,
                AgreedPricePerPrintedRoll = -0.5m,
                AgreedPricePerNonPrintedRoll = 15,
                AgreedShippingRate = 50
            };
            controller.Create(store.Id, newContract);

            Assert.IsNotEmpty(store.Contracts.ToList(), "The stores contract list is empty");
        }
    }
}
