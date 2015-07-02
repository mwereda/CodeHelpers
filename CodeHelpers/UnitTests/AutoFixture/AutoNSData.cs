using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Ploeh.AutoFixture.Xunit;

namespace CodeHelpers.UnitTests.AutoFixture
{
    public class AutoNSData : AutoDataAttribute
    {
        public AutoNSData()
            : base(new Fixture().Customize(new AutoNSubstituteCustomization()))
        {
        }
    }
}
