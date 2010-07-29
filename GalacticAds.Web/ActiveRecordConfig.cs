using Castle.ActiveRecord.Framework.Config;
using Castle.ActiveRecord;
using System.Reflection;
using System.Web.Configuration;
using System.Linq;
using log4net;

namespace GalacticAds.Web
{
    public class ActiveRecordConfig
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MvcApplication));
        public static void Setup()
        {
            var connString = WebConfigurationManager.ConnectionStrings["GalacticAds"];
            LogSanitisedConnectionString(connString);
            var conf = InPlaceConfigurationSource.Build(DatabaseType.MsSqlServer2008, 
                                                        connString.ConnectionString);
            ActiveRecordStarter.Initialize(Assembly.GetExecutingAssembly(), conf);
        }

        private static void LogSanitisedConnectionString(System.Configuration.ConnectionStringSettings connString)
        {
            var elements = connString.ConnectionString.Split(';')
                .Where(x => x.ToLowerInvariant().StartsWith("data source=") ||
                           x.ToLowerInvariant().StartsWith("initial catalog="));
            foreach (var element in elements)
                log.Info(element);
        }
    }
}