using System.Linq;
using NSubstitute;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Xunit;
namespace AutoSitecoreCustomizations.Tests
{
    public class Scenarios
    {
        [Theory, AutoNSubstituteData]
        public void GetFieldValueFromIndexerByName(
            Item item,
            string expected)
        {
            item["field"].Returns(expected);
            Assert.Equal(expected, item["field"]);
        }

        [Theory, AutoNSubstituteData]
        public void GetFieldValueFromIndexerById(
            Item item,
            ID fieldId,
            string expected)
        {
            item[fieldId].Returns(expected);
            Assert.Equal(expected, item[fieldId]);
        }

        [Theory, AutoNSubstituteData]
        public void GetFieldValueByName(
            Item item,
            Field field,
            string expected)
        {
            field.Value.Returns(expected);
            item.Fields[field.Name].Returns(field);
            Assert.Equal(expected, item.Fields[field.Name].Value);
        }

        [Theory, AutoNSubstituteData]
        public void GetFieldValueById(
            Item item,
            Field field,
            string expected)
        {
            field.Value.Returns(expected);
            item.Fields[field.ID].Returns(field);
            Assert.Equal(expected, item.Fields[field.ID].Value);
        }

        [Theory, AutoNSubstituteData]
        public void GetMultilistFieldTargets(
            Item currentItem,
            Field multilistField,
            Item target1,
            Item target2)
        {
            multilistField.Value.Returns($"{target1.ID}|{target2.ID}");
            currentItem.Fields[multilistField.ID].Returns(multilistField);
            currentItem.Database.GetItem(target1.ID).Returns(target1);
            currentItem.Database.GetItem(target2.ID).Returns(target2);

            var sut = new MultilistField(multilistField);
            var actual = sut.GetItems();

            Assert.Same(target1, actual.ElementAt(0));
            Assert.Same(target2, actual.ElementAt(1));
        }

        [Theory, AutoNSubstituteData]
        public void SetCustomTemplateId(Item item, ID expected)
        {
            item.TemplateID.Returns(expected);
            Assert.Same(expected, item.TemplateID);
        }
    }
}
