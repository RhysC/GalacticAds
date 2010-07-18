using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Core.Logging;
using Castle.Windsor;
using Castle.Facilities.Logging;

namespace GalacticAds.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private ILogger logger;
        public ILogger Logger
        {
            get { return logger ?? NullLogger.Instance; }
            set { logger = value; }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
            ActiveRecordConfig.Setup();
            Mappings.RegisterMaps();
        }

        private void ContainerRegistration()
        {
            var container = new WindsorContainer();
            //install all installers
            //container.Install(   new RepositoriesInstaller(),
            //container.AddFacility(

        }
    }
}