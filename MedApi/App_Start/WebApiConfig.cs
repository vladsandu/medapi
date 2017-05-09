using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BusinessServices;
using Unity.WebApi;

namespace MedApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.DependencyResolver = new UnityDependencyResolver(Bootstrapper.Container);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );
        }
    }
}
