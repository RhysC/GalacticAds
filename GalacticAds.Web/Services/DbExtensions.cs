using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Castle.ActiveRecord;
using GalacticAds.Web.Models;
using AutoMapper;

namespace GalacticAds.Web.Services
{
    public static class DbExtensions
    {
        public static T ExecuteStoredProc<T>(string storedProcName, IDictionary<string, object> parameters)
        {
            var factoryHolder = ActiveRecordMediator<Advertiser>.GetSessionFactoryHolder();
            var session = factoryHolder.CreateSession(typeof(Advertiser));
            try
            {
                var cmd = session.Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcName;
                foreach (var parameter in parameters)
                {
                    cmd.AddParameter(parameter.Key, parameter.Value);
                }

                var dataReader = cmd.ExecuteReader();
                //http://elegantcode.com/2009/10/16/mapping-from-idatareaderidatarecord-with-automapper/
                return Mapper.Map<IDataReader, T>(dataReader);
            }
            finally
            {
                factoryHolder.ReleaseSession(session);
            }
        }

        public static void AddParameter(this IDbCommand cmd, string parameterName, object parameterValue)
        {
            var param = cmd.CreateParameter();
            param.ParameterName = string.Format("@{0}", parameterName);
            param.Value = parameterValue;
            cmd.Parameters.Add(param);
        }
    }
}