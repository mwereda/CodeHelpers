using System;
using System.Linq.Expressions;
using System.Reflection;

namespace CodeHelpers
{
	public static class Names
	{
		public static string NameOf<T>(Expression<Func<T, object>> expression)
		{
			Guards.IsNotNull(expression);

			return GetPropertyName(expression);
		}

		public static string NameOf<T>(this T @object, Expression<Func<T, object>> expression)
		{
			Guards.IsNotNull(expression);

			return NameOf(expression);
		}

		private static string GetPropertyName<TPropertySource>(Expression<Func<TPropertySource, object>> expression)
		{
			var lambda = expression as LambdaExpression;
			MemberExpression memberExpression;
			if (lambda.Body is UnaryExpression)
			{
				var unaryExpression = lambda.Body as UnaryExpression;
				memberExpression = unaryExpression.Operand as MemberExpression;
			}
			else
			{
				memberExpression = lambda.Body as MemberExpression;
			}

			if (memberExpression == null)
			{
				return null;
			}

			var propertyInfo = memberExpression.Member as PropertyInfo;
			if (propertyInfo == null)
			{
				return null;
			}

			return propertyInfo.Name;
		}
	}
}
