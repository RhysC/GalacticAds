using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics.Contracts;
using Castle.ActiveRecord;
using GalacticAds.Web.Models;
using GalacticAds.Web.Models.Interfaces;

namespace GalacticAds.Web.Models
{
    [ActiveRecord]
    public class Advertiser : ActiveRecordBase<Advertiser>, IHaveGeographicalLocation
    {
        public Advertiser()
        {
            Categories = new List<Category>();
        }
        [PrimaryKey(PrimaryKeyType.Native)]
        public int Id { get; set; }
        [Property]
        public string Name { get; set; }
        [BelongsTo(Cascade = CascadeEnum.SaveUpdate)]
        public Address GeographicalLocation { get; set; }
        [HasAndBelongsToMany(typeof(Category), Table = "AdvertiserCategory", ColumnKey = "AdvertiserId", ColumnRef = "CategoryId")]
        public IList<Category> Categories { get; set; }
    }

}