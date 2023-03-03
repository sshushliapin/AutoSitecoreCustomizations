using System.Collections.Generic;
using AutoFixture;
using AutoFixture.Kernel;
using NSubstitute;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;

namespace AutoSitecoreCustomizations
{
    internal class ItemCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Item>(x =>
                x.FromFactory(() => CreateItem(fixture))
                    .OmitAutoProperties()
            );
        }

        private static Item CreateItem(ISpecimenBuilder fixture)
        {
            var item = Substitute.For<Item>(
                fixture.Create<ID>(),
                ItemData.Empty,
                fixture.Create<Database>());
            item.Name.Returns("item_" + fixture.Create<string>());
            item.Children.Returns(Substitute.For<ChildList>(item, new List<Item>()));
            item.Fields.Returns(Substitute.For<FieldCollection>(item));

            var language = Language.Parse("en");
            item.Language.Returns(language);
            item.Languages.Returns(new[] { language });
            item.OriginalLanguage.Returns(language);

            var template = Substitute.For<TemplateItem>(Substitute.For<Item>(
                fixture.Create<ID>(),
                ItemData.Empty,
                fixture.Create<Database>()));
            item.Template.Returns(template);
            item.TemplateID.Returns(fixture.Create<ID>());

            item.Version.Returns(Version.First);
            item.Versions.Returns(Substitute.For<ItemVersions>(item));
            item.Versions.Count.Returns(1);

            return item;
        }
    }
}