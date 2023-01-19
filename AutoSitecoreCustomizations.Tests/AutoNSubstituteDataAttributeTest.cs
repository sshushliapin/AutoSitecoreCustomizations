using Sitecore.Data.Items;
using Xunit;

namespace AutoSitecoreCustomizations.Tests
{
    public class AutoNSubstituteDataAttributeTest
    {
        [Theory, AutoNSubstituteData]
        public void CreateItem(Item item)
        {
            Assert.NotNull(item);
        }
    }
}
