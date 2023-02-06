using Sitecore.Data.Fields;
using Xunit;

namespace AutoSitecoreCustomizations.Tests
{
    public class FieldCustomizationTest
    {
        [Theory, AutoNSubstituteData]
        public void CreateFieldSetsRandomId(Field field)
        {
            Assert.False(field.ID.IsNull);
        }

        [Theory, AutoNSubstituteData]
        public void CreateFieldSetsIdBasedName(Field field)
        {
            var expected = $"field_{field.ID}";
            Assert.Equal(expected, field.Name);
        }

        [Theory, AutoNSubstituteData]
        public void CreateFieldSetsDatabase(Field field)
        {
            Assert.NotNull(field.Database);
        }

        [Theory, AutoNSubstituteData]
        public void CreateFieldSetsItem(Field field)
        {
            Assert.NotNull(field.Item);
        }
    }
}