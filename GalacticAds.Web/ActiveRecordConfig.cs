using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
//using System.Web.Configuration;
using Castle.ActiveRecord.Framework.Config;
using System.Collections;
using Castle.ActiveRecord;
using GalacticAds.Web.Models;
using System.Reflection;
using System.Data.SqlClient;
using System.IO;
using log4net;

namespace GalacticAds.Web
{
    public class ActiveRecordConfig
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MvcApplication));
        public static void Setup(System.Configuration.ConnectionStringSettings connString)
        {
            LogSanitisedConnectionString(connString);
            var conf = InPlaceConfigurationSource.Build(DatabaseType.MsSqlServer2008,
                                                        connString.ConnectionString);
            ActiveRecordStarter.Initialize(Assembly.GetExecutingAssembly(), conf);

            ActiveRecordStarter.DropSchema();
            ActiveRecordStarter.GenerateCreationScripts(@"D:\Code\Projects\GalacticAds\SQL\GeneratedCreationScript.sql");
            ActiveRecordStarter.CreateSchema();
            SetUpData(connString.ConnectionString);
        }

        private static void LogSanitisedConnectionString(System.Configuration.ConnectionStringSettings connString)
        {
            var elements = connString.ConnectionString.Split(';')
                .Where(x => x.ToLowerInvariant().StartsWith("data source=") ||
                           x.ToLowerInvariant().StartsWith("initial catalog="));
            foreach (var element in elements)
                log.Info(element);
        }

        private static void SetUpData(string connstr)
        {
            var categoryLoadSql = File.ReadAllText(@"D:\Code\Projects\GalacticAds\SQL\Data\LoadCategories.sql");
            using (var connection = new SqlConnection(connstr))
            {
                connection.Open();
                using (var tx = connection.BeginTransaction())
                using (var cmd = connection.CreateCommand())
                {
                    cmd.Transaction = tx;
                    cmd.CommandText = categoryLoadSql;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                }
            }
        }
    }
}