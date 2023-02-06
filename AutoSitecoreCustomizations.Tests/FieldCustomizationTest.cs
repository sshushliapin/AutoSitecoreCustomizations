using Sitecore.Data.Fields;
using Xunit;

namespace AutoSitecoreCustomizations.Tests
{
    public class FieldCustomizationTest
    {
        [Theory, AutoNSubstituteData]
        public void CreateFieldWithRandomId(Field field)
        {
            Assert.False(field.ID.IsNull);
        }

        [Theory, AutoNSubstituteData]
        public void CreateFieldWithIdBasedName(Field field)
        {
            var expected = $"field_{field.ID}";
            Assert.Equal(expected, field.Name);
        }

        [Theory, AutoNSubstituteData]
        public void CreateFieldWithDatabase(Field field)
        {
            Assert.NotNull(field.Database);
        }

        [Theory, AutoNSubstituteData]
        public void CreateFieldWithItem(Field field)
        {
            Assert.NotNull(field.Item);
        }
    }
}