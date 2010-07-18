using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalacticAds.Web.Models.ViewModels
{
    public class MapItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}