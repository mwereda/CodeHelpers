using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Kernel;
using Ploeh.AutoFixture.Xunit;

namespace CodeHelpers.UnitTests.AutoFixture
{
    public class AutoMoqData : AutoDataAttribute
    {
        public AutoMoqData()
            : base(new Fixture().Customize(new AutoMoqCustomization()))
        {
        }

        public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest, Type[] parameterTypes)
        {
            var specimens = new List<object>();
            foreach (var p in methodUnderTest.GetParameters())
            {
                CustomizeFixture(p);
                if (p.ParameterType.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IMock<>)))
                {
                    var freeze = new FreezingCustomization(p.ParameterType, p.ParameterType);
                    Fixture.Customize(freeze);
                }

                var specimen = Resolve(p);
                specimens.Add(specimen);
            }

            return new[] { specimens.ToArray() };
        }

        private void CustomizeFixture(ParameterInfo p)
        {
            var customizeAttributes = p.GetCustomAttributes(typeof(CustomizeAttribute), inherit: false).OfType<CustomizeAttribute>();
            foreach (var ca in customizeAttributes)
            {
                var c = ca.GetCustomization(p);
                Fixture.Customize(c);
            }
        }

        private object Resolve(ParameterInfo p)
        {
            var context = new SpecimenContext(Fixture);

            return context.Resolve(p);
        }
    }

}
