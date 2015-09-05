using System.Web;
using System.Web.Mvc;

namespace SWZ_Petrol_Station {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
