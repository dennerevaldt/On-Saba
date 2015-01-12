using System.Web;
using System.Web.Mvc;

namespace Associação_Ulbra_Torres
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
