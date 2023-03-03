using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;
using Xunit;

namespace AutoSitecoreCustomizations.Tests
{
    public class ItemCustomizationTest
    {
        [Theory, AutoNSubstituteData]
        public void CreateItemGeneratesRandomId(Item item)
        {
            Assert.False(item.ID.IsNull);
        }

        [Theory, AutoNSubstituteData]
        public void CreateItemSetsName(Item item)
        {
            Assert.StartsWith("item_", item.Name);
        }

        [Theory, AutoNSubstituteData]
        public void CreateItemSetsEmptyChildren(Item item)
        {
            Assert.Empty(item.Children);
        }

        [Theory, AutoNSubstituteData]
        public void CreateItemSetsAxes(Item item)
        {
            Assert.NotNull(item.Axes);
        }

        [Theory, AutoNSubstituteData]
        public void CreateItemSetsEmptyFields(Item item)
        {
            Assert.Empty(item.Fields);
        }

        [Theory, AutoNSubstituteData]
        public void CreateItemSetsEnLanguage(Item item)
        {
            Assert.Equal("en", item.Language.Name);
        }

        [Theory, AutoNSubstituteData]
        public void CreateItemSetsLanguages(Item item)
        {
            Assert.Equal("en", item.Languages.ToList().Single().Name);
        }

        [Theory, AutoNSubstituteData]
        public void CreateItemSetsOriginalLanguage(Item item)
        {
            Assert.Equal("en", item.OriginalLanguage.Name);
        }

        [Theory, AutoNSubstituteData]
        public void CreateItemSetsTemplate(Item item)
        {
            Assert.NotNull(item.Template);
        }

        [Theory, AutoNSubstituteData]
        public void CreateItemSetsTemplateId(Item item)
        {
            Assert.NotNull(item.TemplateID);
        }

        [Theory, AutoNSubstituteData]
        public void CreateItemSetsEqualTemplateId(Item item)
        {
            Assert.Equal(item.TemplateID, item.Template.ID);
            Assert.Equal(item.TemplateID, item.Template.InnerItem.ID);
        }

        [Theory, AutoNSubstituteData]
        public void CreateItemSetsVersionFirst(Item item)
        {
            Assert.Equal(Version.First, item.Version);
        }

        [Theory, AutoNSubstituteData]
        public void CreateItemSetsVersions(Item item)
        {
            Assert.NotNull(item.Versions);
        }

        [Theory, AutoNSubstituteData]
        public void CreateItemSetsVersionCount(Item item)
        {
            Assert.Equal(1, item.Versions.Count);
        }
    }
}
