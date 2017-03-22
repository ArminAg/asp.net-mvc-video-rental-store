using asp.net_mvc_video_rental_store.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace asp.net_mvc_video_rental_store
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MapperConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
