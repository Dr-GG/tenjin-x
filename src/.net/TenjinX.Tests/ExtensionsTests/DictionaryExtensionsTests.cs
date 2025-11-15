using FluentAssertions;
using TenjinX.Extensions;
using TenjinX.Tests.TestFixtures;

namespace TenjinX.Tests.ExtensionsTests;

public static class DictionaryExtensionsTests
{
    [Fact]
    public static void DoesNotContainKey_ShouldReturnTrue_WhenKeyIsAbsent()
    {
        CollectionTestFixtures.PartialFruitDictionary
            .DoesNotContainKey(4)
            .Should()
            .BeTrue();
    }

    [Fact]
    public static void DoesNotContainKey_ShouldReturnFalse_WhenKeyIsPresent()
    {
        CollectionTestFixtures.PartialFruitDictionary
            .DoesNotContainKey(2)
            .Should()
            .BeFalse();
    }

    [Fact]
    public static void TryAdd_WhenCalledWithFunctionWithItemsThatDoNotExist_ShouldAddItemAndReturnTrue()
    {
        var dictionary = CollectionTestFixtures.PartialFruitDictionary;
        var result = dictionary.TryAdd(4, () => "Date");

        result.Should().BeTrue();
        dictionary.Should().ContainKey(4).WhoseValue.Should().Be("Date");
    }

    [Fact]
    public static void TryAdd_WhenCalledWithFunctionWithItemsThatExist_ShouldNotAddItemAndReturnFalse()
    {
        var dictionary = CollectionTestFixtures.PartialFruitDictionary;
        var result = dictionary.TryAdd(2, () => "Blueberry");

        result.Should().BeFalse();
        dictionary.Should().NotContainKey(4);
        dictionary[2].Should().Be("Banana");
    }

    [Fact]
    public static void TryAdd_WhenCalledWithAsyncFunctionWithItemsThatDoNotExist_ShouldAddItemAndReturnTrue()
    {
        var dictionary = CollectionTestFixtures.PartialFruitDictionary;
        var result = dictionary.TryAdd(4, async () =>
        {
            await Task.Delay(10);
            return "Date";
        });

        result.Should().BeTrue();
        dictionary.Should().ContainKey(4).WhoseValue.Should().Be("Date");
    }

    [Fact]
    public static void TryAdd_WhenCalledWithAsyncFunctionWithItemsThatExist_ShouldNotAddItemAndReturnFalse()
    {
        var dictionary = CollectionTestFixtures.PartialFruitDictionary;
        var result = dictionary.TryAdd(2, async () =>
        {
            await Task.Delay(10);
            return "Blueberry";
        });

        result.Should().BeFalse();
        dictionary.Should().NotContainKey(4);
        dictionary[2].Should().Be("Banana");
    }
}
