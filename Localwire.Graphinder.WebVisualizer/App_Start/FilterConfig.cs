using System.Web;
using System.Web.Mvc;

namespace Localwire.Graphinder.WebVisualizer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
