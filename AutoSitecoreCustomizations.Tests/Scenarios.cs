using NSubstitute;
using Sitecore.Data;
using Sitecore.Data.Items;
using Xunit;
namespace AutoSitecoreCustomizations.Tests
{
    public class Scenarios
    {
        [Theory, AutoNSubstituteData]
        public void SetCustomTemplateId(Item item, ID expected)
        {
            item.TemplateID.Returns(expected);
            Assert.Same(expected, item.TemplateID);
        }
    }
}
