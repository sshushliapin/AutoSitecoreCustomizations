using AutoFixture;
using AutoFixture.Kernel;
using NSubstitute;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace AutoSitecoreCustomizations
{
    internal class FieldCustomization : ICustomization
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
            var field = Substitute.For<Field>(
                fixture.Create<ID>(),
                item);
            field.Database.Returns(item.Database);

            return field;
        }
    }
}