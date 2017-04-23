using System.Web.Http;
using System.Web.Mvc;
using BusinessEntities.Character;
using BusinessServices;
using DependencyResolver;
using Microsoft.Practices.Unity;

namespace MedApi
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            System.Web.Mvc.DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);
            
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            //Component initialization via MEF
            ComponentLoader.LoadContainer(container, ".\\bin", "MedApi.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "BusinessServices.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "DataAccess.dll");
        }
    }
}