using AutoFixture.Xunit2;
using Xunit;

namespace AutoSitecoreCustomizations
{
    public class InlineAutoNSubstituteDataAttribute : CompositeDataAttribute
    {
        public InlineAutoNSubstituteDataAttribute(params object[] values)
            : base(new InlineDataAttribute(values), new AutoNSubstituteDataAttribute())
        {
        }
    }
}