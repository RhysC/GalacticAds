using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord.Framework.Config;
using System.Collections;
using Castle.ActiveRecord;
using GalacticAds.Web.Models;
using System.Reflection;
using System.Data.SqlClient;
using System.IO;

namespace GalacticAds.Web
{
    public class ActiveRecordConfig
    {
        public static void Setup()
        {
            var conf = InPlaceConfigurationSource.BuildForMSSqlServer(".\\sqlexpress", "GalacticAds");
            ActiveRecordStarter.Initialize(Assembly.GetExecutingAssembly(), conf);
            //ActiveRecordStarter.DropSchema();
            //ActiveRecordStarter.CreateSchema();
            //SetUpData();
        }
        private static void SetUpData()
        {
            var categoryLoadSql = File.ReadAllText(@"D:\Code\Projects\GalacticAds\GalacticAds.Web\SQL\Data\LoadCategories.sql");
            using (var connection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=GalacticAds;Integrated Security=True"))
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