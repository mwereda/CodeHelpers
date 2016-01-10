using Castle.Windsor;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel;

namespace CodeHelpers.DI.Castle
{
    public static class ContainerRegistrationExtensions
    {
        public static void Register<TInterface, TImplementation>(this IWindsorContainer containter)
            where TImplementation : TInterface
            where TInterface : class
        {
            containter.Register<TInterface, TImplementation, TransientLifestyleManager>();
        }

        public static void Register<TInterface, TImplementation>(this IWindsorContainer containter, string name)
            where TImplementation : TInterface
            where TInterface : class
        {
            containter.Register<TInterface, TImplementation, TransientLifestyleManager>(name);
        }

        public static void Register<TInterface, TImplementation>(this IWindsorContainer containter, Dependency dependency)
            where TImplementation : TInterface
            where TInterface : class
        {
            containter.Register<TInterface, TImplementation, TransientLifestyleManager>(dependency);
        }

        public static void Register<TInterface, TImplementation>(this IWindsorContainer containter, Dependency dependency, string name)
            where TImplementation : TInterface
            where TInterface : class
        {
            containter.Register<TInterface, TImplementation, TransientLifestyleManager>(dependency, name);
        }

        public static void Register<TInterface, TImplementation, TLifescope>(this IWindsorContainer containter)
            where TImplementation : TInterface
            where TInterface : class
            where TLifescope : ILifestyleManager, new()
        {
            containter.Register(Component.For<TInterface>().ImplementedBy<TImplementation>().LifestyleCustom<TLifescope>());
        }

        public static void Register<TInterface, TImplementation, TLifescope>(this IWindsorContainer containter, string name)
            where TImplementation : TInterface
            where TInterface : class
            where TLifescope : ILifestyleManager, new()
        {
            containter.Register(Component.For<TInterface>().ImplementedBy<TImplementation>().LifestyleCustom<TLifescope>().Named(name));
        }

        public static void Register<TInterface, TImplementation, TLifescope>(this IWindsorContainer containter, Dependency dependency)
            where TImplementation : TInterface
            where TInterface : class
            where TLifescope : ILifestyleManager, new()
        {
            containter.Register(Component.For<TInterface>().ImplementedBy<TImplementation>().LifestyleCustom<TLifescope>().DependsOn(dependency));
        }

        public static void Register<TInterface, TImplementation, TLifescope>(this IWindsorContainer containter, Dependency dependency, string name)
            where TImplementation : TInterface
            where TInterface : class
            where TLifescope : ILifestyleManager, new()
        {
            containter.Register(Component.For<TInterface>().ImplementedBy<TImplementation>().LifestyleCustom<TLifescope>().DependsOn(dependency).Named(name));
        }

        public static void RegisterInstance<TInterface>(this IWindsorContainer containter, TInterface instance)
           where TInterface : class
        {
            containter.RegisterInstance<TInterface, TransientLifestyleManager>(instance);
        }

        public static void RegisterInstance<TInterface>(this IWindsorContainer containter, TInterface instance, string name)
           where TInterface : class
        {
            containter.RegisterInstance<TInterface, TransientLifestyleManager>(instance, name);
        }

        public static void RegisterInstance<TInterface>(this IWindsorContainer containter, TInterface instance, Dependency dependency)
          where TInterface : class
        {
            containter.RegisterInstance<TInterface, TransientLifestyleManager>(instance, dependency);
        }

        public static void RegisterInstance<TInterface>(this IWindsorContainer containter, TInterface instance, Dependency dependency, string name)
          where TInterface : class
        {
            containter.RegisterInstance<TInterface, TransientLifestyleManager>(instance, dependency, name);
        }

        public static void RegisterInstance<TInterface, TLifescope>(this IWindsorContainer containter, TInterface instance)
            where TInterface : class
            where TLifescope : ILifestyleManager, new()
        {
            containter.Register(Component.For<TInterface>().Instance(instance).LifestyleCustom<TLifescope>());
        }

        public static void RegisterInstance<TInterface, TLifescope>(this IWindsorContainer containter, TInterface instance, string name)
           where TInterface : class
           where TLifescope : ILifestyleManager, new()
        {
            containter.Register(Component.For<TInterface>().Instance(instance).LifestyleCustom<TLifescope>().Named(name));
        }

        public static void RegisterInstance<TInterface, TLifescope>(this IWindsorContainer containter, TInterface instance, Dependency dependency)
           where TInterface : class
           where TLifescope : ILifestyleManager, new()
        {
            containter.Register(Component.For<TInterface>().Instance(instance).LifestyleCustom<TLifescope>().DependsOn(dependency));
        }

        public static void RegisterInstance<TInterface, TLifescope>(this IWindsorContainer containter, TInterface instance, Dependency dependency, string name)
           where TInterface : class
           where TLifescope : ILifestyleManager, new()
        {
            containter.Register(Component.For<TInterface>().Instance(instance).LifestyleCustom<TLifescope>().DependsOn(dependency).Named(name));
        }
    }
}
