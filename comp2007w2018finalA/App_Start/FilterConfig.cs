using System.Web;
using System.Web.Mvc;

namespace comp2007w2018finalA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
