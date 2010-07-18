using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalacticAds.Web.Models
{
    /// <summary>
    /// An advert that represents a printed advert
    /// </summary>
    public class Advert
    {
        public Advertiser Owner { get; set; }
        /// <summary>
        /// The start date of the ad if it is a temporaly relevant ads
        /// </summary>
        public DateTime? Start { get; set; }
        /// <summary>
        /// The end date of the ad if it is a temporaly relevant ads
        /// </summary>
        public DateTime? End { get; set; }
        public byte[] Image { get; set; }
        public bool IsImageApproved { get; set; }
    }
}