using FluentAssertions;
using TenjinX.Extensions;
using TenjinX.Tests.TestFixtures;

namespace TenjinX.Tests.ExtensionsTests;

public static class ListExtensionsTests
{
    [Fact]
    public static void RemoveRangeAt_ShouldRemoveItemsAtSpecifiedIndexes()
    {
        var list = CollectionTestFixtures.FullFruitEnumerable.ToList();
        var duplicateList = list.ToList();

        duplicateList.RemoveAt(5);
        duplicateList.RemoveAt(3);
        duplicateList.RemoveAt(1);

        list.RemoveRangeAt(1, 3, 5);

        list.Should().BeEquivalentTo(duplicateList);
    }

    [Fact]
    public static void BinaryInsert_WhenUsingItemAndDoesNotExist_ShouldInsertItemAtCorrectIndex()
    {
        var list = CollectionTestFixtures.FullFruitEnumerable.ToList();
        var expected = list.ToList();

        expected.Insert(2, "Blueberry");

        list.BinaryInsert("Blueberry").Should().Be(2);
        list.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public static void BinaryInsert_WhenUsingItemAndExists_ShouldNotInsertItem()
    {
        var list = CollectionTestFixtures.FullFruitEnumerable.ToList();
        var expected = list.ToList();

        expected.Insert(1, "Banana");

        list.BinaryInsert("Banana").Should().Be(1);
        list.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public static void BinaryInsert_WhenUsingComparerFuncAndDoesNotExist_ShouldInsertItemAtCorrectIndex()
    {
        var list = CollectionTestFixtures.FullFruitEnumerable.ToList();
        var expected = list.ToList();

        expected.Insert(2, "Blueberry");

        list.BinaryInsert("Blueberry", StringComparer.Ordinal.Compare).Should().Be(2);
        list.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public static void BinaryInsert_WhenUsingComparerFuncAndExists_ShouldNotInsertItem()
    {
        var list = CollectionTestFixtures.FullFruitEnumerable.ToList();
        var expected = list.ToList();

        expected.Insert(1, "Banana");

        list.BinaryInsert("Banana", StringComparer.Ordinal.Compare).Should().Be(1);
        list.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public static void BinaryInsert_WhenUsingComparerAndDoesNotExist_ShouldInsertItemAtCorrectIndex()
    {
        var list = CollectionTestFixtures.FullFruitEnumerable.ToList();
        var expected = list.ToList();

        expected.Insert(2, "Blueberry");

        list.BinaryInsert("Blueberry", StringComparer.Ordinal).Should().Be(2);
        list.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public static void BinaryInsert_WhenUsingComparerAndExists_ShouldNotInsertItem()
    {
        var list = CollectionTestFixtures.FullFruitEnumerable.ToList();
        var expected = list.ToList();

        list.BinaryInsert("Banana", StringComparer.Ordinal).Should().Be(1);
        expected.Insert(1, "Banana");
    }
}
