using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using GalacticAds.Web.Models;
using AutoMapper;
using System.Data;
using GalacticAds.Web.Models.ViewModels;

namespace GalacticAds.Web.Services
{
    public class LocationQueryService
    {
        public IEnumerable<MapItem> FindAdvertisersLocalStores(int advertiserId, int proximityinKm)
        {
            return DbExtensions.ExecuteStoredProc<IEnumerable<MapItem>>(
                "[dbo].[FindStoresNearAdvertiser]",
                new Dictionary<string, object> { 
                    { "AdvertiserId", advertiserId }, 
                    { "DistanceInKm", 5 } }
                );
        }

       
    }
}