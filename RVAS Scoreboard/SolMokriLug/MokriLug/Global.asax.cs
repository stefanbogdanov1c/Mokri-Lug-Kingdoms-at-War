using MokriLug.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MokriLug
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            clsDatabaseConnection clsDatabaseConnection = new clsDatabaseConnection();
            clsDatabaseConnection.CheckIFExists();
            clsDatabaseConnection.CreateTableIfNOtExists();
            AreaRegistration.RegisterAllAreas();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
