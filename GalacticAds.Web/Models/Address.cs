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
        public decimal Latitude { get; protected set; }
        [Property]
        public decimal Longitude { get; protected set; }
        [Property]
        public bool IsGeoLocationConfirmed { get; set; }

        public override string ToString()
        {
            var x = new List<object>();
            AddToListIfNotNullOrWhiteSpace(x, StreetAddress);
            AddToListIfNotNullOrWhiteSpace(x, Suburb);
            AddToListIfNotNullOrWhiteSpace(x, City);
            AddToListIfNotNullOrWhiteSpace(x, PostCode);
            AddToListIfNotNullOrWhiteSpace(x, Provence);
            AddToListIfNotNullOrWhiteSpace(x, Country);
            return string.Join(", ", x);
        }
        private static void AddToListIfNotNullOrWhiteSpace(IList<object> list,string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                list.Add(value);
        }

        internal void AddKnownGeoLocation(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            IsGeoLocationConfirmed = true;
        }
        internal void AddEstimatedGeoLocation(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            IsGeoLocationConfirmed = false;
        }
    }
}
