using AutoFixture;
using AutoFixture.Kernel;
using NSubstitute;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace AutoSitecoreCustomizations
{
    public class FieldCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Field>(x =>
                x.FromFactory(() => CreateField(fixture))
                    .OmitAutoProperties()
            );
        }

        private static Field CreateField(ISpecimenBuilder fixture)
        {
            var item = fixture.Create<Item>();
            var fieldId = fixture.Create<ID>();
            var field = Substitute.For<Field>(
                fieldId,
                item);
            field.Database.Returns(item.Database);
            field.Name.Returns($"field_{fieldId}");

            return field;
        }
    }
}