using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace CodeHelpers.Patterns.Databases
{
	public class IdentityMap<T, TKey> where T : class
	{
		private readonly int invalidatedInSeconds;

		private readonly IDictionary<TKey, IdentityMapElement<T>> map;

		public IdentityMap()
			: this(600)
		{
		}

		public IdentityMap(int invalidatedInSeconds)
		{
			this.invalidatedInSeconds = invalidatedInSeconds;
			this.map = new ConcurrentDictionary<TKey, IdentityMapElement<T>>();
		}

		public T Get(TKey key)
		{
			var element = this.map.FirstOrDefault(x => x.Key.Equals(key));
			if (element.Value == null)
			{
				return null;
			}

			if (element.Value.Created.AddSeconds(this.invalidatedInSeconds) < DateTime.UtcNow)
			{
				this.map.Remove(key);
				return null;
			}

			return element.Value.Object;
		}

		public void Add(TKey key, T item)
		{
			var existingObject = Get(key);
			if (existingObject != null)
			{
				this.map.Remove(key);
			}

			this.map.Add(key, new IdentityMapElement<T>(item, DateTime.UtcNow));
		}

		public int Count()
		{
			return this.map.Count();
		}
	}
}
