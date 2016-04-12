using Microsoft.Practices.Unity;
using Starter.Web.Core.Injection;
using Plants.Web.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using System.Linq;
using Unity.Mvc5;
using System.Web.Http.Filters;
using Starter.Web.Core.Services;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Starter.Web.Controllers;

namespace Plants.Web
{
    public static class UnityConfig
    {
        private static UnityContainer _container;

        public static UnityContainer GetContainer()
        {
            return _container;
        }

        public static void RegisterComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();

            container.RegisterType<IPlantsService, PlantsService>(new TransientLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //  this line is needed so that the resolver can be used by api controllers 
            config.DependencyResolver = new Starter.Web.Core.Injection.UnityResolver(container);

            //web api filters
            List<System.Web.Http.Filters.IFilterProvider> providers = config.Services.GetFilterProviders().ToList();

            config.Services.Add(typeof(System.Web.Http.Filters.IFilterProvider),
                                                            new UnityActionFilterProvider(container));

            System.Web.Http.Filters.IFilterProvider defaultprovider = providers.First(p => p is ActionDescriptorFilterProvider);

            config.Services.Remove(typeof(System.Web.Http.Filters.IFilterProvider), defaultprovider);
        
            _container = container;
        }
    }
}