using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using System.ComponentModel;

namespace GalacticAds.Web.Models
{
    [ActiveRecord]
    public class Address : ActiveRecordBase<Address>
    {
        [PrimaryKey(PrimaryKeyType.Native)]
        public int Id { get; set; }
        [Property]
        [DisplayName("Street Address")]
        public string StreetAddress { get; set; }
        [Property]
        public string Suburb { get; set; }
        [Property]
        public string City { get; set; }
        [Property]
        [DisplayName("Post Code")]
        public string PostCode { get; set; }
        [Property]
        public string Provence { get; set; }
        [Property]
        public string Country { get; set; }
        [Property]
        public decimal Latitude { get; set; }
        [Property]
        public decimal Longitude { get; set; }
    }
}
