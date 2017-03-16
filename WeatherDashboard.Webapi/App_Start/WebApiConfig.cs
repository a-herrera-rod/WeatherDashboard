using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;

namespace WeatherDashboard.Webapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {   
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();            

            //Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "services/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
