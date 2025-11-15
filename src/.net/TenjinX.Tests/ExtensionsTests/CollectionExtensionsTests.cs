using FluentAssertions;
using TenjinX.Extensions;
using TenjinX.Tests.TestFixtures;

namespace TenjinX.Tests.ExtensionsTests;

public static class CollectionExtensionsTests
{
    [Fact]
    public static void AddRange_AddingMultipleItems_ShouldAddAllItemsToCollection()
    {
        var collection = CollectionTestFixtures.PartialFruitCollection;
        var itemsToAdd = CollectionTestFixtures.AdditionalFruitEnumerable.ToArray();

        collection.AddRange(itemsToAdd);
        collection.Should().BeEquivalentTo(CollectionTestFixtures.FullFruitEnumerable);
    }

    [Fact]
    public static void RemoveRange_RemovingMultipleItems_ShouldRemoveAllItemsFromCollection()
    {
        var collection = CollectionTestFixtures.FullFruitCollection;
        var itemsToRemove = CollectionTestFixtures.AdditionalFruitEnumerable.ToArray();

        collection.RemoveRange(itemsToRemove);
        collection.Should().BeEquivalentTo(CollectionTestFixtures.PartialFruitEnumerable);
    }
}
