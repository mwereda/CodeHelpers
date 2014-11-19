using System;
using CodeHelpers.Tests.TestDoubles;
using NUnit.Framework;

namespace CodeHelpers.Tests
{
	public class GuardsTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotNull_PassedNullObject_ThrowsArgumentNullException()
		{
			Guards.IsNotNull(null);
		}

		[Test]
		public void IsNotNull_PassedNotNullObject_ExceptionNotThrown()
		{
			Assert.DoesNotThrow(() => Guards.IsNotNull(new DummyClass()));
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotNullOrEmpty_PassedNullString_ThrowsArgumentNullException()
		{
			DummyClass dummy = new DummyClass();			
			Guards.IsNotNullOrEmpty(null);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotNullOrEmpty_PassedEmptyString_ThrowsArgumentNullException()
		{
			Guards.IsNotNullOrEmpty(string.Empty);
		}

		[Test]
		public void IsNotNullOrEmpty_PassedValidString_ExceptionNotThrown()
		{
			Assert.DoesNotThrow(() => Guards.IsNotNullOrEmpty("test string"));
		}
	}
}
