using Exceptionless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Dollar
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Excepcionless
            ExceptionlessClient.Default.Configuration.DefaultData["FirstName"] = "CiudadDelDollar";
            ExceptionlessClient.Default.Configuration.DefaultData["IgnoredProperty"] = "ERROR";

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ExceptionlessClient.Default.Configuration.UseTraceLogger();
            ExceptionlessClient.Default.Configuration.UseReferenceIds();
            ExceptionlessClient.Default.RegisterWebApi(GlobalConfiguration.Configuration);
        }
    }
}
