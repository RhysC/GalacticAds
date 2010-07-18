using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalacticAds.Web.Models.ViewModels
{
    public class ProximityResult
    {
        public MapItem Record { get; set; }
        public IEnumerable<MapItem> Associations { get; set; }
    }
}