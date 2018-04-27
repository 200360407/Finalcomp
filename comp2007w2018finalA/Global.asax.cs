using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace comp2007w2018finalA
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Manually installed WebAPI 2.2 after making an MVC project.
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };

            //GlobalConfiguration.Configuration.Formatters.Clear();
            //GlobalConfiguration.Configuration.Formatters.Add(new JsonNetFormatter(jsonSerializerSettings));

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
