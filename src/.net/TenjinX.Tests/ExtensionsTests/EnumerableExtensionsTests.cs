using FluentAssertions;
using TenjinX.Extensions;
using TenjinX.Models.Enumerables;
using TenjinX.Tests.TestFixtures;

namespace TenjinX.Tests.ExtensionsTests;

public static class EnumerableExtensionsTests
{
    [Fact]
    public static void EnumerateToList_WhenCalledOnAnEnumerable_ShouldReturnListWithSameItems()
    {
        var enumerable = CollectionTestFixtures.FullFruitEnumerable;
        var list = CollectionTestFixtures.FullFruitEnumerable.EnumerateToList();

        list.Should().BeOfType<List<string>>();
        list.Should().BeEquivalentTo(enumerable);
    }

    [Fact]
    public static void EnumerateToList_WhenCalledOnAnExistingList_ShouldReturnSameListInstance()
    {
        var list = CollectionTestFixtures.FullFruitEnumerable.ToList();
        var resultList = list.EnumerateToList();

        resultList.Should().BeSameAs(list);
    }

    [Fact]
    public static void IsEmpty_WhenEnumerableHasNoItems__ShouldReturnTrue()
    {
        var emptyEnumerable = Enumerable.Empty<string>();
        var result = emptyEnumerable.IsEmpty();

        result.Should().BeTrue();
    }

    [Fact]
    public static void IsEmpty_WhenEnumerableHasItems_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.FullFruitEnumerable;
        var result = enumerable.IsEmpty();

        result.Should().BeFalse();
    }

    [Fact]
    public static void IsNotEmpty_WhenEnumerableHasNoItems__ShouldReturnFalse()
    {
        var emptyEnumerable = Enumerable.Empty<string>();
        var result = emptyEnumerable.IsNotEmpty();

        result.Should().BeFalse();
    }

    [Fact]
    public static void IsNotEmpty_WhenEnumerableHasItems_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.FullFruitEnumerable;
        var result = enumerable.IsNotEmpty();

        result.Should().BeTrue();
    }

    [Fact]
    public static void IsNullOrEmpty_WhenEnumerableIsNull_ShouldReturnTrue()
    {
        IEnumerable<string>? enumerable = null;
        var result = enumerable.IsNullOrEmpty();

        result.Should().BeTrue();
    }

    [Fact]
    public static void IsNullOrEmpty_WhenEnumerableIsEmpty_ShouldReturnTrue()
    {
        var emptyEnumerable = Enumerable.Empty<string>();
        var result = emptyEnumerable.IsNullOrEmpty();

        result.Should().BeTrue();
    }

    [Fact]
    public static void IsNullOrEmpty_WhenEnumerableHasItems_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.FullFruitEnumerable;
        var result = enumerable.IsNullOrEmpty();

        result.Should().BeFalse();
    }

    [Fact]
    public static void IsNotNullOrEmpty_WhenEnumerableIsNull_ShouldReturnFalse()
    {
        IEnumerable<string>? enumerable = null;
        var result = enumerable.IsNotNullOrEmpty();

        result.Should().BeFalse();
    }

    [Fact]
    public static void IsNotNullOrEmpty_WhenEnumerableIsEmpty_ShouldReturnFalse()
    {
        var emptyEnumerable = Enumerable.Empty<string>();
        var result = emptyEnumerable.IsNotNullOrEmpty();

        result.Should().BeFalse();
    }

    [Fact]
    public static void IsNotNullOrEmpty_WhenEnumerableHasItems_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.FullFruitEnumerable;
        var result = enumerable.IsNotNullOrEmpty();

        result.Should().BeTrue();
    }

    [Fact]
    public static void LastIndexOf_UsingItemAndItemExists_ShouldReturnLastIndex()
    {
        var list = CollectionTestFixtures.FullFruitEnumerable.ToList();

        list.Add("Banana");

        list
            .LastIndexOf("Banana")
            .Should()
            .Be(7);
    }

    [Fact]
    public static void LastIndexOf_UsingItemAndItemDoesNotExist_ShouldReturnNegativeOne()
    {
        CollectionTestFixtures
            .FullFruitEnumerable
            .LastIndexOf("Pineapple")
            .Should()
            .Be(-1);
    }

    [Fact]
    public static void LastIndexOf_UsingPredicateAndItemExists_ShouldReturnLastIndex()
    {
        CollectionTestFixtures
            .FullFruitEnumerable
            .LastIndexOf(fruit => fruit.EndsWith("e"))
            .Should()
            .Be(6);
    }

    [Fact]
    public static void LastIndexOf_UsingPredicateAndItemDoesNotExist_ShouldReturnNegativeOne()
    {
        CollectionTestFixtures
            .FullFruitEnumerable
            .LastIndexOf(fruit => fruit.StartsWith("P"))
            .Should()
            .Be(-1);
    }

    [Fact]
    public static void IndexOf_UsingPredicateAndItemDoesNotExist_ShouldReturnIndex()
    {
        CollectionTestFixtures
            .FullFruitEnumerable
            .IndexOf(fruit => fruit.StartsWith("B"))
            .Should()
            .Be(1);
    }

    [Fact]
    public static void IndexOf_UsingPredicateAndItemDoesNotExist_ShouldReturnNegativeOne()
    {
        CollectionTestFixtures
            .FullFruitEnumerable
            .IndexOf(fruit => fruit.StartsWith("P"))
            .Should()
            .Be(-1);
    }

    [Fact]
    public static void LastIndex_WhenCalled_ShouldReturnLastIndex()
    {
        var index = CollectionTestFixtures.FullFruitEnumerable.Count() - 1;

        CollectionTestFixtures
            .FullFruitEnumerable
            .LastIndex()
            .Should()
            .Be(index);
    }

    [Fact]
    public static void LastIndex_WhenCalledOnEmptyEnumerable_ShouldReturnNegativeOne()
    {
        Enumerable
            .Empty<string>()
            .LastIndex()
            .Should()
            .Be(-1);
    }

    [Fact]
    public static void ToJoinedString_WhenCalled_ShouldReturnJoinedString()
    {
        var enumerable = CollectionTestFixtures.FullFruitEnumerable;
        var joinedString = enumerable.ToJoinedString(", ");
        var realJoinedString = string.Join(", ", enumerable);

        joinedString.Should().Be(realJoinedString);
    }

    [Fact]
    public static void ToJoinedString_WhenCalledOnEmptyEnumerable_ShouldReturnEmptyString()
    {
        var emptyEnumerable = Enumerable.Empty<string>();
        var joinedString = emptyEnumerable.ToJoinedString(", ");

        joinedString.Should().Be(string.Empty);
    }

    [Fact]
    public static void PartitionInto_WhenNumberOfPartitionsIsInvalid_ThrowsAnException()
    {
        var enumerable = CollectionTestFixtures.FullFruitEnumerable;
        var actZero = () => enumerable.PartitionInto(0).ToList();

        actZero.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public static void PartitionInto_WhenItemsAreEvenlyDistributable_ShouldReturnEvenPartitions()
    {
        var enumerable = CollectionTestFixtures.FullNumberEnumerable;
        var partitions = enumerable.PartitionInto(5).ToList();

        partitions.Should().HaveCount(5);
        partitions[0].Should().BeEquivalentTo([1, 2]);
        partitions[1].Should().BeEquivalentTo([3, 4]);
        partitions[2].Should().BeEquivalentTo([5, 6]);
        partitions[3].Should().BeEquivalentTo([7, 8]);
        partitions[4].Should().BeEquivalentTo([9, 10]);
    }

    [Fact]
    public static void PartitionInto_WhenItemsAreNotEvenlyDistributable_ShouldReturnUnevenPartitions()
    {
        var enumerable = CollectionTestFixtures.FullNumberEnumerable;
        var partitions = enumerable.PartitionInto(3).ToList();

        partitions.Should().HaveCount(3);
        partitions[0].Should().BeEquivalentTo([1, 2, 3,]);
        partitions[1].Should().BeEquivalentTo([4, 5, 6]);
        partitions[2].Should().BeEquivalentTo([7, 8, 9, 10]);
    }

    [Fact]
    public static void PartitionInto_WhenNumberOfPartitionsExceedsItemCount_ShouldReturnTheMinimumPartitions()
    {
        var enumerable = CollectionTestFixtures.FullNumberEnumerable;
        var partitions = enumerable.PartitionInto(20).ToList();

        partitions.Should().HaveCount(10);

        for (int i = 0; i < 10; i++)
        {
            partitions[i].Should().BeEquivalentTo([i + 1]);
        }
    }

    [Fact]
    public static void PartitionInto_WhenNumberOfPartitionsIsOne_ShouldReturnSinglePartitionWithAllItems()
    {
        var enumerable = CollectionTestFixtures.FullNumberEnumerable;
        var partitions = enumerable.PartitionInto(1).ToList();

        partitions.Should().HaveCount(1);
        partitions[0].Should().BeEquivalentTo(enumerable);
    }

    [Fact]
    public static void PartitionInto_WhenCalledOnEmptyEnumerable_ShouldReturnNoPartitions()
    {
        var enumerable = Enumerable.Empty<int>();
        var partitions = enumerable.PartitionInto(3).ToList();

        partitions.Should().BeEmpty();
    }

    [Fact]
    public static void Contains_WhenUsingPredicateAndItemExists_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.FullFruitEnumerable;
        var result = enumerable.Contains(fruit => fruit.StartsWith("C"));

        result.Should().BeTrue();
    }

    [Fact]
    public static void Contains_WhenUsingPredicateAndItemDoesNotExist_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.FullFruitEnumerable;
        var result = enumerable.Contains(fruit => fruit.StartsWith("P"));

        result.Should().BeFalse();
    }

    [Fact]
    public static void DoesNotContain_WhenUsingItemAndItemExists_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.FullFruitEnumerable;
        var result = enumerable.DoesNotContain("Banana");
        result.Should().BeFalse();
    }

    [Fact]
    public static void DoesNotContain_WhenUsingItemAndItemDoesNotExist_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.FullFruitEnumerable;
        var result = enumerable.DoesNotContain("Pineapple");

        result.Should().BeTrue();
    }

    [Fact]
    public static void DoesNotContain_WhenUsingPredicateAndItemExists_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.FullFruitEnumerable;
        var result = enumerable.DoesNotContain(fruit => fruit.StartsWith("C"));

        result.Should().BeFalse();
    }

    [Fact]
    public static void DoesNotContain_WhenUsingPredicateAndItemDoesNotExist_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.FullFruitEnumerable;
        var result = enumerable.DoesNotContain(fruit => fruit.StartsWith("P"));

        result.Should().BeTrue();
    }

    [Fact]
    public static void ContainsAll_WhenUsingItemsAndAllItemsExist_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.PartialFruitEnumerable;
        var itemsToCheck = CollectionTestFixtures.PartialFruitEnumerable;
        var result = enumerable.ContainsAll(itemsToCheck);

        result.Should().BeTrue();
    }

    [Fact]
    public static void ContainsAll_WhenUsingItemsAndNotAllItemsExist_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.PartialFruitEnumerable;
        var itemsToCheck = CollectionTestFixtures.AdditionalFruitEnumerable;
        var result = enumerable.ContainsAll(itemsToCheck);

        result.Should().BeFalse();
    }

    [Fact]
    public static void ContainsAll_WhenUsingPredicateAndAllItemsMatch_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.PartialNumberEnumerable;
        var result = enumerable.ContainsAll(number => number > 0);

        result.Should().BeTrue();
    }

    [Fact]
    public static void ContainsAll_WhenUsingPredicateAndNotAllItemsMatch_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.PartialNumberEnumerable;
        var result = enumerable.ContainsAll(number => number > 2);

        result.Should().BeFalse();
    }

    [Fact]
    public static void ContainsAny_WhenUsingItemsAndAtLeastOneItemExists_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.PartialFruitEnumerable;
        var itemsToCheck = CollectionTestFixtures.FullFruitEnumerable;
        var result = enumerable.ContainsAny(itemsToCheck);

        result.Should().BeTrue();
    }

    [Fact]
    public static void ContainsAny_WhenUsingItemsAndNoItemsExist_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.PartialFruitEnumerable;
        var itemsToCheck = CollectionTestFixtures.AdditionalFruitEnumerable;
        var result = enumerable.ContainsAny(itemsToCheck);

        result.Should().BeFalse();
    }

    [Fact]
    public static void ContainsAny_WhenUsingPredicateAndAtLeastOneItemMatches_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.PartialNumberEnumerable;
        var result = enumerable.ContainsAny(number => number > 3);

        result.Should().BeTrue();
    }

    [Fact]
    public static void ContainsAny_WhenUsingPredicateAndNoItemsMatch_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.PartialNumberEnumerable;
        var result = enumerable.ContainsAny(number => number > 5);

        result.Should().BeFalse();
    }

    [Fact]
    public static void DoesNotContainAll_WhenUsingItemsAndAllItemsExist_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.PartialFruitEnumerable;
        var itemsToCheck = CollectionTestFixtures.PartialFruitEnumerable;
        var result = enumerable.DoesNotContainAll(itemsToCheck);

        result.Should().BeFalse();
    }

    [Fact]
    public static void DoesNotContainAll_WhenUsingItemsAndNotAllItemsExist_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.PartialFruitEnumerable;
        var itemsToCheck = CollectionTestFixtures.AdditionalFruitEnumerable;
        var result = enumerable.DoesNotContainAll(itemsToCheck);

        result.Should().BeTrue();
    }

    [Fact]
    public static void DoesNotContainAll_WhenUsingPredicateAndAllItemsMatch_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.PartialNumberEnumerable;
        var result = enumerable.DoesNotContainAll(number => number > 0);

        result.Should().BeFalse();
    }

    [Fact]
    public static void DoesNotContainAll_WhenUsingPredicateAndNotAllItemsMatch_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.PartialNumberEnumerable;
        var result = enumerable.DoesNotContainAll(number => number > 2);

        result.Should().BeTrue();
    }

    [Fact]
    public static void DoesNotContainAny_WhenUsingItemsAndAtLeastOneItemExists_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.PartialFruitEnumerable;
        var itemsToCheck = CollectionTestFixtures.FullFruitEnumerable;
        var result = enumerable.DoesNotContainAny(itemsToCheck);

        result.Should().BeFalse();
    }

    [Fact]
    public static void DoesNotContainAny_WhenUsingItemsAndNoItemsExist_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.PartialFruitEnumerable;
        var itemsToCheck = CollectionTestFixtures.AdditionalFruitEnumerable;
        var result = enumerable.DoesNotContainAny(itemsToCheck);

        result.Should().BeTrue();
    }

    [Fact]
    public static void DoesNotContainAny_WhenUsingPredicateAndAtLeastOneItemMatches_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.PartialNumberEnumerable;
        var result = enumerable.DoesNotContainAny(number => number > 3);

        result.Should().BeFalse();
    }

    [Fact]
    public static void DoesNotContainAny_WhenUsingPredicateAndNoItemsMatch_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.PartialNumberEnumerable;
        var result = enumerable.DoesNotContainAny(number => number > 5);

        result.Should().BeTrue();
    }

    [Fact]
    public static void ForEach_WhenCalledWithAction_ShouldPerformActionOnEachItem()
    {
        var enumerable = CollectionTestFixtures.PartialNumberEnumerable;
        var sum = 0;

        enumerable.ForEach(number => sum += number);

        sum.Should().Be(enumerable.Sum());
    }

    [Fact]
    public static void ForEach_WhenCalledWithActionWithIndex_ShouldPerformActionOnEachItemWithIndex()
    {
        var enumerable = CollectionTestFixtures.PartialNumberEnumerable;
        var sum = 0;
        var expectedSum = enumerable
            .Select((number, index) => number * index)
            .Sum();

        enumerable.ForEach((number, index) => sum += number * index);

        sum.Should().Be(expectedSum);
    }

    [Fact]
    public static void ForEach_WhenCalledWithTenjinContextOnANonEmptyEnumerable_ShouldPerformActionOnEachItemWithContext()
    {
        var enumerable = CollectionTestFixtures.PartialFruitEnumerable;
        var results = GetForEachTenjinContextData(enumerable);
        var expectedResults = new List<string>
        {
            "Apple:0:First",
            "Banana:1:InBetween",
            "Cherry:2:Last"
        };

        results.Should().BeEquivalentTo(expectedResults);
    }

    [Fact]
    public static void ForEach_WhenCalledWithTenjinContextOnASingleItemEnumerable_ShouldPerformActionOnTheItemWithContext()
    {
        var enumerable = CollectionTestFixtures.PartialFruitEnumerable.Take(1);
        var results = GetForEachTenjinContextData(enumerable);
        var expectedResults = new List<string>
        {
            "Apple:0:First:Last"
        };

        results.Should().BeEquivalentTo(expectedResults);
    }

    [Fact]
    public static void BinarySearch_WithFunctionComparerAndItemExists_ShouldReturnItemIndex()
    {
        var enumerable = CollectionTestFixtures.FullNumberEnumerable.ToList();
        var itemToFind = 7;
        var index = enumerable.BinarySearch(itemToFind, (a, b) => a.CompareTo(b));

        index.Should().Be(enumerable.IndexOf(itemToFind));
    }

    [Fact]
    public static void BinarySearch_WithFunctionComparerAndItemDoesNotExist_ShouldReturnNegativeBinarySearchIndex()
    {
        var enumerable = CollectionTestFixtures.FullNumberEnumerable.ToList();

        enumerable.Remove(5);

        var index = enumerable.BinarySearch(5, (a, b) => a.CompareTo(b));

        index.Should().Be(-5);
    }

    [Fact]
    public static void BinarySearch_WithIComparerAndItemExists_ShouldReturnItemIndex()
    {
        var enumerable = CollectionTestFixtures.FullNumberEnumerable.ToList();
        var itemToFind = 7;
        var comparer = Comparer<int>.Default;
        var index = enumerable.BinarySearch(itemToFind, comparer);

        index.Should().Be(enumerable.IndexOf(itemToFind));
    }

    [Fact]
    public static void BinarySearch_WithIComparerAndItemDoesNotExist_ShouldReturnNegativeBinarySearchIndex()
    {
        var enumerable = CollectionTestFixtures.FullNumberEnumerable.ToList();

        enumerable.Remove(5);

        var comparer = Comparer<int>.Default;
        var index = enumerable.BinarySearch(5, comparer);

        index.Should().Be(-5);
    }

    [Fact]
    public static void BinarySearchContains_WithItemAndItemExists_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.FullNumberEnumerable.ToList();
        var contains = enumerable.BinarySearchContains(7);

        contains.Should().BeTrue();
    }

    [Fact]
    public static void BinarySearchContains_WithItemAndItemDoesNotExist_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.FullNumberEnumerable.ToList();
        var contains = enumerable.BinarySearchContains(100);

        contains.Should().BeFalse();
    }

    [Fact]
    public static void BinarySearchContains_WithFunctionComparerAndItemExists_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.FullNumberEnumerable.ToList();
        var contains = enumerable.BinarySearchContains(7, (a, b) => a.CompareTo(b));

        contains.Should().BeTrue();
    }

    [Fact]
    public static void BinarySearchContains_WithFunctionComparerAndItemDoesNotExist_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.FullNumberEnumerable.ToList();
        var contains = enumerable.BinarySearchContains(100, (a, b) => a.CompareTo(b));

        contains.Should().BeFalse();
    }

    [Fact]
    public static void BinarySearchContains_WithIComparerItemExists_ShouldReturnTrue()
    {
        var enumerable = CollectionTestFixtures.FullNumberEnumerable.ToList();
        var contains = enumerable.BinarySearchContains(7, Comparer<int>.Default);

        contains.Should().BeTrue();
    }

    [Fact]
    public static void BinarySearchContains_WithIComparerAndItemDoesNotExist_ShouldReturnFalse()
    {
        var enumerable = CollectionTestFixtures.FullNumberEnumerable.ToList();
        var contains = enumerable.BinarySearchContains(100, Comparer<int>.Default);

        contains.Should().BeFalse();
    }

    [Fact]
    public static void GetCollectionHashCode_WhenCalled_ShouldReturnSameHashCodeAsExpected()
    {
        var list = CollectionTestFixtures.FullNumberEnumerable.ToList();
        var expectedHashCode = new HashCode();
        var actualHashCode = list.GetCollectionHashCode();

        foreach (var item in list)
        {
            expectedHashCode.Add(item);
        }

        actualHashCode.Should().Be(expectedHashCode.ToHashCode());
    }

    private static IEnumerable<string> GetForEachTenjinContextData(IEnumerable<string> items)
    {
        var results = new List<string>();

        items.ForEach((context, item) =>
        {
            var result = $"{item}:{context.Index}";

            if (context.IsFirst)
            {
                result += ":First";
            }

            if (context.IsLast)
            {
                result += ":Last";
            }

            if (context.IsInBetween)
            {
                result += ":InBetween";
            }

            results.Add(result);
        });

        return results;
    }
}
