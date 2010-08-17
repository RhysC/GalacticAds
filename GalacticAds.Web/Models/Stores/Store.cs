using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using GalacticAds.Web.Models.Interfaces;
using GalacticAds.Web.Models.Stores;

namespace GalacticAds.Web.Models
{
    /// <summary>
    /// A store that will recieve reciepts rolls with adverts
    /// </summary>
    [ActiveRecord]
    public class Store : ActiveRecordBase<Store>, IHaveGeographicalLocation
    {
        public Store()
        {
            Contracts = new List<StoreContract>();
            RollUsageHistory = new List<RollUsage>();
        }
        [PrimaryKey(PrimaryKeyType.Native, UnsavedValue = "0")]
        public int Id { get; set; }
        [Property]
        public string Name { get; set; }
        [BelongsTo(Cascade = CascadeEnum.SaveUpdate)]
        public Address GeographicalLocation { get; set; }

        [HasMany(Inverse = true, Cascade = ManyRelationCascadeEnum.All)]
        public IList<StoreContract> Contracts { get; set; }
        [HasMany(Inverse = true, Cascade = ManyRelationCascadeEnum.All)]
        public IList<RollUsage> RollUsageHistory { get; set; }


        internal void AddContract(StoreContract contract)
        {
            this.Contracts.Add(contract);
            contract.Store = this;
        }
        public StoreContract GetCurrentContract()
        {
            var now = DateTime.Now;
            return (from contract in Contracts
                    where contract.StartDate <= now &&
                          contract.EndDate >= now
                    orderby contract.EndDate
                    select contract)
                    .FirstOrDefault();
        }


    }
}
