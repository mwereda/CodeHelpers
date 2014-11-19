using System;
using CodeHelpers.Tests.TestDoubles;
using NUnit.Framework;

namespace CodeHelpers.Tests
{
	public class NamesTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NameOf_PassedNullExpression_ThrowsArgumentNullException()
		{
			Names.NameOf<DummyClass>(null);
		}

		[Test]
		public void NameOf_PassedValidExpression_ReturnsValidPropertyName()
		{			
			var propertyName = Names.NameOf<DummyClass>(x => x.DummyProperty);
			Assert.AreEqual("DummyProperty", propertyName);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NameOfExtension_PassedNullExpression_ThrowsArgumentNullException()
		{
			var dummy = new DummyClass();
			dummy.NameOf(null);
		}

		[Test]
		public void NameOfExtension_PassedValidExpression_ReturnsValidPropertyName()
		{
			var dummy = new DummyClass();
			string propertyName = dummy.NameOf(x => x.DummyProperty);
			
			Assert.AreEqual("DummyProperty", propertyName);
		}
	}
}
