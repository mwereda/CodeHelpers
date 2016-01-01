using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace CodeHelpers.MVC.DependencyInjection
{
    /// <summary>
    /// Castle.Windsor controller factory for ASP.NET MVC.
    /// To use it put these lines into Global.asax.cs:
    /// 
    /// var castleControllerFactory = new CastleControllerFactory(container);
    /// ControllerBuilder.Current.SetControllerFactory(castleControllerFactory);
    /// </summary>
    public class CastleControllerFactory : DefaultControllerFactory
    {
        public IWindsorContainer Container
        {
            get; protected set;
        }

        public CastleControllerFactory(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.Container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            return Container.Resolve(controllerType) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            var disposableController = controller as IDisposable;
            if (disposableController != null)
            {
                disposableController.Dispose();
            }

            Container.Release(controller);
        }
    }
}
