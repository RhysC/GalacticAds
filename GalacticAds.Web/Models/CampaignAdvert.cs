using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalacticAds.Web.Models
{
    public class CampaignAdvert
    {
        public Advert Advert { get; set; }
        public Campaign Campaign { get; set; }
        public bool PaymentRecieved { get; set; }
    }
}