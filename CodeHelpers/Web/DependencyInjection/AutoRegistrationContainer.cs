using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace CodeHelpers.Web.DependencyInjection
{
    public static class AutoRegistrationContainer
    {
        public static IWindsorContainer Configure()
        {
            var container = new WindsorContainer();

            var controllers = GetControllers();
            foreach (var controller in controllers)
            {
                container.Register(Component.For(controller).LifestylePerWebRequest());
            }

            var assemblies = GetAssemblies();
            foreach (var assembly in assemblies.Distinct())
            {
                container.Register(Classes.FromAssemblyNamed(assembly.Name).Pick().WithServiceAllInterfaces().LifestylePerWebRequest());
            }

            return container;
        }

        private static IList<AssemblyName> GetAssemblies()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var referencedAssemblies = GetReferencedAssemblies(executingAssembly).ToList();

            for (int i = referencedAssemblies.Count - 1; i >= 0; i--)
            {
                referencedAssemblies.AddRange(GetReferencedAssemblies(Assembly.Load(referencedAssemblies[i])));
            }
            referencedAssemblies.Add(executingAssembly.GetName());

            return referencedAssemblies;
        }

        private static IList<AssemblyName> GetReferencedAssemblies(Assembly assembly)
        {
            return assembly.GetReferencedAssemblies().Where(x => x.Name.StartsWith("BiteSquare")).ToList();
        }

        private static IList<Type> GetControllers()
        {
            var controllers = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(Controller) || x.BaseType == typeof(ApiController)).ToList();

            return controllers;
        }
    }
}
