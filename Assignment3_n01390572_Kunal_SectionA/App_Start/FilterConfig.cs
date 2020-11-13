using System.Web;
using System.Web.Mvc;

namespace Assignment3_n01390572_Kunal_SectionA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
