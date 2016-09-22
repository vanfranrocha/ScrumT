using System.Web;
using System.Web.Mvc;

namespace Ferramenta_Scrumt
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
