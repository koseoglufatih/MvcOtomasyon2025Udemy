using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
