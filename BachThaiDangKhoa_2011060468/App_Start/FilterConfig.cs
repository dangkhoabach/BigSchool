using System.Web;
using System.Web.Mvc;

namespace BachThaiDangKhoa_2011060468
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
