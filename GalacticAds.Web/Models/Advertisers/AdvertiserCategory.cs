using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using GalacticAds.Web.Models;
using Castle.ActiveRecord.Queries;
using NHibernate.Criterion;

namespace GalacticAds.Web.Models
{
    [ActiveRecord]
    public class Category : ActiveRecordBase<Category>
    {
        [PrimaryKey(PrimaryKeyType.Native)]
        public int Id { get; set; }
        [Property]
        public string Name { get; set; }
        [HasAndBelongsToMany(typeof(Advertiser), Table = "AdvertiserCategory", ColumnKey = "CategoryId", ColumnRef = "AdvertiserId")]
        public IList<Advertiser> Advertisers { get; set; }
    }
}