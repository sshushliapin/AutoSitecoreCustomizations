# AutoSitecore Customizations

This repo contains a list of [AutoFixture customizations](https://autofixture.github.io/docs/fixture-customization/#) intended to simplify unit testing in Sitecore projects. It's not a library or framework like [FakeDb](https://github.com/sshushliapin/Sitecore.FakeDb). It's rather a collection of simple helpers that can be copied into existing codebase and adjusted as needed.

A typical unit test in Sitecore project requires an item with some fields specified. With the Sitecore AutoFixture customizations it can be achieved with the following code:

```c#
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
```

A bit more advanced scenario. An item contains a multilist field with references to other items:

```c#
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
```
