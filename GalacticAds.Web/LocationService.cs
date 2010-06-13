using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using GalacticAds.Web.Models;
using System.Diagnostics.Contracts;
using System.Xml.Linq;

namespace GalacticAds.Web
{
    public class LocationService
    {
        public static void SetGeographicalLocation(Address address)
        {
            Contract.Requires(address != null);
            var rooturl = "http://maps.google.com/maps/api/geocode/xml?address=";
            var tailurl = "&sensor=false";
            var appendedString = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(address.StreetAddress))
            {
                appendedString.Append(address.StreetAddress.Trim().Replace("  ", " ").Replace(" ", "+"));
            }
            CleanAndAppendAddressPart(appendedString, address.Suburb);
            CleanAndAppendAddressPart(appendedString, address.City);
            CleanAndAppendAddressPart(appendedString, address.Provence);
            CleanAndAppendAddressPart(appendedString, address.PostCode);
            CleanAndAppendAddressPart(appendedString, address.Country);

            appendedString.Insert(0, rooturl);
            appendedString.Append(tailurl);
            var url = appendedString.ToString();
            var xmldata = XDocument.Load(url);
            var response = xmldata.Element("GeocodeResponse");
            if (response.Element("status").Value.ToUpperInvariant() != "OK")
                return;
            var location = response.Element("result").Element("geometry").Element("location");            
            address.Latitude = decimal.Parse(location.Element("lat").Value);
            address.Longitude = decimal.Parse(location.Element("lng").Value);
            //$lat = $xmldata.GeocodeResponse.result.geometry.location.lat
            //$lng = $xmldata.GeocodeResponse.result.geometry.location.lng
            //return @{ "Lat" = $lat; "Long" = $lng; "StreetAddress" = $StreetAddress; "City" = $City; "State" = $State; "Zip" = $Zip}	
        }

        private static void CleanAndAppendAddressPart(StringBuilder appendedString, string addressPart)
        {
            if (!string.IsNullOrWhiteSpace(addressPart))
            {
                if (appendedString.Length > 0)
                    appendedString.Append(",+");
                appendedString.Append(addressPart.Trim().Replace("  ", " ").Replace(" ", "+"));
            }
        }

    }
}