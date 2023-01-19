using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace AutoSitecoreCustomizations
{
    public class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute()
            : base(() => new Fixture()
                .Customize(new AutoNSubstituteCustomization())
                .Customize(new DatabaseCustomization())
                .Customize(new ItemCustomization())
                .Customize(new FieldCustomization()))
        {
        }
    }
}