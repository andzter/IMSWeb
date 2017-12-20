using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Http;

namespace IMSWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        public static string SessionTimeOut()
        {
            var sessionSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            return sessionSection.Timeout.Minutes.ToString();
        }

        public static int PageSize()
        {
            int iCount = 25;
            int.TryParse(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString(), out iCount);
            if (iCount == 0) iCount = 25;
            return iCount;
        }
    }
}
