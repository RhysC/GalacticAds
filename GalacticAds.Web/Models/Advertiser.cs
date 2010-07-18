using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using GalacticAds.Web.Models;
using GalacticAds.Web.Models.Interfaces;
using NHibernate;

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

        public IList<Store> FindLocalStores(int proximityinKm)
        {
            return (IList<Store>)ActiveRecordMediator<Advertiser>.Execute(
                     delegate(ISession session, object instance)
                     {
                         return session.CreateSQLQuery("FindStoresNearAdvertiser")
                             .SetParameter("AdvertiserId", this.Id)
                             .SetParameter("DistanceInKm", proximityinKm)
                             .List<Store>();
                     }, this);

        }

        private const string FindStoreNearAdvertiser = @"
            declare @AdvertiserLocation geography 
	        select top 1 @AdvertiserLocation = location 
	        from Address a
	        where a.Id = @AdvertiserId
	
	        SELECT a.* 
	        FROM
		        Store s
			        inner join 
		        Address a on s.GeographicalLocation = a.Id
	        WHERE a.Location.STDistance(@AdvertiserLocation) < @DistanceInKm";
    }

}