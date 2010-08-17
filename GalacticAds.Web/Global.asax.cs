using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Core.Logging;
using Castle.Windsor;
using Castle.Facilities.Logging;
using log4net;
using log4net.Config;
using System.Web.Configuration;

namespace GalacticAds.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MvcApplication));
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
            XmlConfigurator.Configure(new FileInfo(HttpContext.Current.Server.MapPath("Log4Net.config")));

            log.Info("Application start");
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            var connString = WebConfigurationManager.ConnectionStrings["GalacticAds"];
            ActiveRecordConfig.Setup(connString);
            Mappings.RegisterMaps();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            log.Error(ex);
        }
    }
}