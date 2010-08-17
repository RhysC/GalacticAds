using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace GalacticAds.Web.Models.Stores
{
    [ActiveRecord]
    public class RollUsage
    {
        [PrimaryKey(PrimaryKeyType.Native)]
        public int Id { get; set; }
        [BelongsTo("StoreId")]
        public Store Store { get; set; }
        [Nested]
        public DateRange Period { get; set; }
        [Property]
        public int NumberOfRollsUsed { get; set; }
    }
}
