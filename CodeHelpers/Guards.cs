using System;

namespace CodeHelpers
{
	public static class Guards
	{
		public static void IsNotNull(object @object)
		{
			if (@object == null)
			{
				throw new ArgumentNullException("object");
			}
		}

		public static void IsNotNullOrEmpty(string @string)
		{
			if (string.IsNullOrEmpty(@string))
			{
				throw new ArgumentNullException("string");
			}
		}		
	}
}
