using AutoFixture;
using NSubstitute;
using Sitecore.Data;

namespace AutoSitecoreCustomizations
{
    internal class DatabaseCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Inject(Substitute.For<Database>());
        }
    }
}