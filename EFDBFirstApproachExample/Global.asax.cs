using System.Web.Mvc;
using System.Web.Routing;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;


namespace EFDBFirstApproachExample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilter(GlobalFilters.Filters);
            
        }
    }
}
