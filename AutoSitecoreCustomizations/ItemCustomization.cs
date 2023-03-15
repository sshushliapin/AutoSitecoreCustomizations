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
            var name = "item_" + fixture.Create<string>();
            item.Name.Returns(name);
            item.Children.Returns(Substitute.For<ChildList>(item, new List<Item>()));
            item.Fields.Returns(Substitute.For<FieldCollection>(item));

            item.Axes.Returns(Substitute.For<ItemAxes>(item));

            var language = Language.Parse("en");
            item.Language.Returns(language);
            item.Languages.Returns(new[] { language });
            item.OriginalLanguage.Returns(language);
            item.Paths.Returns(Substitute.For<ItemPath>(item));
            item.Paths.FullPath.Returns($"/sitecore/content/home/{name}");

            var templateId = fixture.Create<ID>();
            var template = Substitute.For<TemplateItem>(Substitute.For<Item>(
                templateId,
                ItemData.Empty,
                fixture.Create<Database>()));
            template.ID.Returns(templateId);
            item.Template.Returns(template);
            item.TemplateID.Returns(templateId);

            item.Version.Returns(Version.First);
            item.Versions.Returns(Substitute.For<ItemVersions>(item));
            item.Versions.Count.Returns(1);

            return item;
        }
    }
}