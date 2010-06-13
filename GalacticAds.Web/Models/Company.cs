using Castle.ActiveRecord;

namespace GalacticAds.Web.Models
{
    [ActiveRecord]
    public class Company : ActiveRecordBase<Company>
    {
        [PrimaryKey(PrimaryKeyType.Native)]
        public int Id { get; set; }
        [Property]
        public string Name { get; set; }
    }
}