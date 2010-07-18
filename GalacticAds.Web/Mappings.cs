using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using GalacticAds.Web.Models.ViewModels;

namespace GalacticAds.Web
{
    public class Mappings
    {
        internal static void RegisterMaps()
        {
            AutoMapper.Mapper.CreateMap<IDataReader, IEnumerable<MapItem>>();
        }
    }
}