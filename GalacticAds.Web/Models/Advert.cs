using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalacticAds.Web.Models
{
    public class Advert
    {
        public Advertiser Owner { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public byte[] Image { get; set; }
        public bool IsImageApproved { get; set; }
    }
}