using System.Web;
using System.Web.Mvc;

namespace MarlonPolanco_COVID19Report
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
