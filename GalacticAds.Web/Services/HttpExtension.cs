using System.Web;

namespace GalacticAds.Web.Services
{
    public static class HttpExtension
    {
        public static bool HasFile(this HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }
    }
}