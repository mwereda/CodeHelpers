using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace CodeHelpers.WebAPI.DependencyInjection
{
    public static class ContainerExtensions
    {
        public static void RegisterApiControllers(this IWindsorContainer container)
        {
            var controllers = GetControllers(Assembly.GetExecutingAssembly());
            foreach (var controller in controllers)
            {
                container.Register(Component.For(controller).LifestylePerWebRequest());
            }
        }

        public static void RegisterApiControllers(this IWindsorContainer container, Assembly assembly)
        {
            var controllers = GetControllers(assembly);
            foreach (var controller in controllers)
            {
                container.Register(Component.For(controller).LifestylePerWebRequest());
            }
        }

        private static IList<Type> GetControllers(Assembly assembly)
        {
            var controllers = assembly.GetTypes().Where(x => x.BaseType == typeof(ApiController)).ToList();

            return controllers;
        }
    }
}
