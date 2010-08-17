using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalacticAds.Web.Models
{
    /// <summary>
    ///A campaign represents a period of advertising in which an advertiser
    ///is prepared to advertise with a given set of stores using a given number of adverts
    /// </summary>
    public class Campaign
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Store> Stores { get; set; }
        public List<CampaignAdvert> Adverts { get; set; }
        public object BarcodeFormat { get; set; }
        /// <summary>
        /// The identifier of the campaign for the distributors to use
        /// </summary>
        public object Barcode { get; set; }
        /// <summary>
        /// the distributor that will recieve the printed roles and distribute the roles to the store
        /// </summary>
        public object Distributor { get; set; }
    }
   
}