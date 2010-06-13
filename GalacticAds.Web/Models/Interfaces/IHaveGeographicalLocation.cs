using GalacticAds.Web.Models;

namespace GalacticAds.Web.Models.Interfaces
{
    public interface IHaveGeographicalLocation
    {
        Address GeographicalLocation { get; set; }
    }
}
