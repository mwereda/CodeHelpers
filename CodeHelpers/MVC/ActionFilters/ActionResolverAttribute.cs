using System.Reflection;
using System.Web.Mvc;

namespace CodeHelpers.MVC.ActionFilters
{
	public class ActionResolverAttribute : ActionMethodSelectorAttribute
	{
		private readonly string[] parameters;

		public ActionResolverAttribute(params string[] parameterNames)
		{
			this.parameters = parameterNames;
		}

		public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
		{
			foreach (var param in this.parameters)
			{
				if (controllerContext.HttpContext.Request[param] == null)
				{
					return false;
				}
			}

			return true;
		}
	}
}
