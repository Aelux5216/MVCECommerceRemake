using System.Web;
using System.Web.Mvc;

namespace MVC_E_Commerce_Remake
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
