using System;

namespace CodeHelpers.Patterns.Databases
{
	public class IdentityMapElement<T> where T : class
	{
		public IdentityMapElement(T @object, DateTime created)
		{
			Object = @object;
			Created = created;
		}

		public T Object { get; private set; }
		public DateTime Created { get; private set; }
	}
}
