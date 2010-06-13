using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalacticAds.Web.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Store> Stores { get; set; }
        public List<CampaignAdvert> Adverts { get; set; }
        public object BarcodeFormat { get; set; }
        public object Barcode { get; set; }
        public object Distributor { get; set; }
    }
   
}