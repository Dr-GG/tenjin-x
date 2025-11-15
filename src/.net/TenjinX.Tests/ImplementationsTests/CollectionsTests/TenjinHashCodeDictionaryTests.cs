using FluentAssertions;
using TenjinX.Implementations.Collections;
using TenjinX.Tests.TestFixtures;

namespace TenjinX.Tests.ImplementationsTests.CollectionsTests;

public class TenjinHashCodeDictionaryTests
{
    private readonly IEnumerable<string> _testEnumerable = CollectionTestFixtures.FullFruitEnumerable;
    private readonly TenjinHashCodeDictionary<string> _dictionary = new(CollectionTestFixtures.FullFruitEnumerable);

    [Fact]
    public void Constructor_WhenCalledWithEnumerable_ShouldInitializeDictionary()
    {
        var dictionary = new TenjinHashCodeDictionary<string>(_testEnumerable);

        dictionary.Count.Should().Be(_testEnumerable.Count());
        dictionary.Values.Should().BeEquivalentTo(_testEnumerable);
    }

    [Fact]
    public void Constructor_WhenCalledWithOtherDictionary_ShouldInitializeDictionary()
    {
        var anotherDictionary = new TenjinHashCodeDictionary<string>(_dictionary);

        anotherDictionary.Count.Should().Be(_dictionary.Count);
        anotherDictionary.Values.Should().BeEquivalentTo(_dictionary.Values);
    }

    [Fact]
    public void Constructor_WhenCalledWithKeyValuePairCollection_ShouldInitializeDictionary()
    {
        var kvpCollection = _testEnumerable.Select(item => new KeyValuePair<int, string>(item.GetHashCode(), item)).ToList();
        var dictionary = new TenjinHashCodeDictionary<string>(kvpCollection);

        dictionary.Count.Should().Be(_testEnumerable.Count());
        dictionary.Values.Should().BeEquivalentTo(_testEnumerable);
    }

    [Fact]
    public void IsReadOnly_WhenCalled_ShouldReturnFalse()
    {
        _dictionary.IsReadOnly.Should().BeFalse();
    }

    [Fact]
    public void Count_WhenCalled_ShouldReturnExpectedCount()
    {
        _dictionary.Count.Should().Be(_testEnumerable.Count());
    }

    [Fact]
    public void Keys_WhenCalled_ShouldReturnExpectedKeys()
    {
        var expectedKeys = _testEnumerable.Select(item => item.GetHashCode()).ToList();

        _dictionary.Keys.Should().BeEquivalentTo(expectedKeys);
    }

    [Fact]
    public void Values_WhenCalled_ShouldReturnExpectedValues()
    {
        _dictionary.Values.Should().BeEquivalentTo(_testEnumerable);
    }

    [Fact]
    public void Indexer_GetWithKey_ShouldReturnExpectedValue()
    {
        foreach (var item in _testEnumerable)
        {
            var key = item.GetHashCode();
            var value = _dictionary[key];

            value.Should().Be(item);
        }
    }

    [Fact]
    public void Indexer_SetWithKey_ShouldUpdateValue()
    {
        var newItem = "Dragonfruit";
        var key = newItem.GetHashCode();

        _dictionary[key] = newItem;
        _dictionary[key].Should().Be(newItem);
    }

    [Fact]
    public void Indexer_GetWithItem_ShouldReturnExpectedValue()
    {
        foreach (var item in _testEnumerable)
        {
            var value = _dictionary[item];

            value.Should().Be(item);
        }
    }

    [Fact]
    public void Indexer_SetWithItem_ShouldUpdateValue()
    {
        var newItem = "Elderberry";

        _dictionary[newItem] = newItem;
        _dictionary[newItem].Should().Be(newItem);
    }

    [Fact]
    public void GetEnumerator_WhenCalled_ShouldReturnAllItems()
    {
        var items = _dictionary.ToList();
        var enumerator = _dictionary.GetEnumerator();

        foreach (var item in items)
        {
            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(item);
        }
    }

    [Fact]
    public void NonGenericGetEnumerator_WhenCalled_ShouldReturnAllItems()
    {
        var items = _dictionary.ToList();
        var enumerator = ((System.Collections.IEnumerable)_dictionary).GetEnumerator();

        foreach (var item in items)
        {
            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(item);
        }
    }

    [Fact]
    public void TryAdd_WhenItemExists_ShouldNotAddItem()
    {
        var existingItem = _testEnumerable.First();
        var result = _dictionary.TryAdd(existingItem);

        result.Should().BeFalse();
        _dictionary.Count.Should().Be(_testEnumerable.Count());
    }

    [Fact]
    public void TryAdd_WhenItemDoesNotExist_ShouldAddItem()
    {
        var newItem = "Starfruit";
        var result = _dictionary.TryAdd(newItem);

        result.Should().BeTrue();
        _dictionary.Count.Should().Be(_testEnumerable.Count() + 1);
        _dictionary[newItem].Should().Be(newItem);
    }

    [Fact]
    public void Add_WithKeyAndValue_ShouldAddItem()
    {
        var newItem = "Grapefruit";
        var key = newItem.GetHashCode();

        _dictionary.Add(key, newItem);
        _dictionary.Count.Should().Be(_testEnumerable.Count() + 1);
        _dictionary[key].Should().Be(newItem);
    }

    [Fact]
    public void Add_WithItem_ShouldAddItem()
    {
        var newItem = "Honeydew";

        _dictionary.Add(newItem);
        _dictionary.Count.Should().Be(_testEnumerable.Count() + 1);
        _dictionary[newItem].Should().Be(newItem);
    }

    [Fact]
    public void Add_WithKeyValuePair_ShouldAddItem()
    {
        var newItem = "Indian Fig";
        var key = newItem.GetHashCode();
        var kvp = new KeyValuePair<int, string>(key, newItem);

        _dictionary.Add(kvp);
        _dictionary.Count.Should().Be(_testEnumerable.Count() + 1);
        _dictionary[key].Should().Be(newItem);
    }

    [Fact]
    public void Clear_WhenCalled_ShouldRemoveAllItems()
    {
        _dictionary.Clear();
        _dictionary.Count.Should().Be(0);
    }

    [Fact]
    public void ContainsKey_WhenKeyExists_ShouldReturnTrue()
    {
        var existingItem = _testEnumerable.First();
        var key = existingItem.GetHashCode();
        var result = _dictionary.ContainsKey(key);

        result.Should().BeTrue();
    }

    [Fact]
    public void ContainsKey_WhenKeyDoesNotExist_ShouldReturnFalse()
    {
        var newItem = "Jackfruit";
        var key = newItem.GetHashCode();
        var result = _dictionary.ContainsKey(key);

        result.Should().BeFalse();
    }

    [Fact]
    public void Contains_WhenKeyValuePairExists_ShouldReturnTrue()
    {
        var existingItem = _testEnumerable.First();
        var key = existingItem.GetHashCode();
        var kvp = new KeyValuePair<int, string>(key, existingItem);
        var result = _dictionary.Contains(kvp);

        result.Should().BeTrue();
    }

    [Fact]
    public void Contains_WhenKeyValuePairDoesNotExist_ShouldReturnFalse()
    {
        var newItem = "Kiwi";
        var key = newItem.GetHashCode();
        var kvp = new KeyValuePair<int, string>(key, newItem);
        var result = _dictionary.Contains(kvp);

        result.Should().BeFalse();
    }

    [Fact]
    public void Contains_WhenItemExists_ShouldReturnTrue()
    {
        var existingItem = _testEnumerable.First();
        var result = _dictionary.Contains(existingItem);

        result.Should().BeTrue();
    }

    [Fact]
    public void Contains_WhenItemDoesNotExist_ShouldReturnFalse()
    {
        var newItem = "Lemon";
        var result = _dictionary.Contains(newItem);

        result.Should().BeFalse();
    }

    [Fact]
    public void CopyTo_DestinationIsKeyValuePairArray_ShouldCopyAllItems()
    {
        var array = new KeyValuePair<int, string>[_dictionary.Count];

        _dictionary.CopyTo(array, 0);

        for (int i = 0; i < array.Length; i++)
        {
            var item = _dictionary.ElementAt(i);

            array[i].Should().Be(item);
        }
    }

    [Fact]
    public void CopyTo_DestinationIsTenjinHashCodeDictionary_ShouldCopyAllItems()
    {
        var destination = new TenjinHashCodeDictionary<string>();

        _dictionary.CopyTo(destination);

        destination.Count.Should().Be(_dictionary.Count);

        foreach (var item in _dictionary)
        {
            destination[item.Key].Should().Be(item.Value);
        }
    }

    [Fact]
    public void Remove_WithKeyValuePairAndExistingItem_ShouldRemoveItem()
    {
        var existingItem = _testEnumerable.First();
        var key = existingItem.GetHashCode();
        var kvp = new KeyValuePair<int, string>(key, existingItem);
        var result = _dictionary.Remove(kvp);

        result.Should().BeTrue();
        _dictionary.Count.Should().Be(_testEnumerable.Count() - 1);
        _dictionary.ContainsKey(key).Should().BeFalse();
    }

    [Fact]
    public void Remove_WithKeyValuePairAndNonExistingItem_ShouldNotRemoveItem()
    {
        var newItem = "Mango";
        var key = newItem.GetHashCode();
        var kvp = new KeyValuePair<int, string>(key, newItem);
        var result = _dictionary.Remove(kvp);

        result.Should().BeFalse();
        _dictionary.Count.Should().Be(_testEnumerable.Count());
    }

    [Fact]
    public void Remove_WithItemAndExistingItem_ShouldRemoveItem()
    {
        var existingItem = _testEnumerable.First();
        var result = _dictionary.Remove(existingItem);

        result.Should().BeTrue();
        _dictionary.Count.Should().Be(_testEnumerable.Count() - 1);
        _dictionary.ContainsKey(existingItem.GetHashCode()).Should().BeFalse();
    }

    [Fact]
    public void Remove_WithItemAndNonExistingItem_ShouldNotRemoveItem()
    {
        var newItem = "Nectarine";
        var result = _dictionary.Remove(newItem);

        result.Should().BeFalse();
        _dictionary.Count.Should().Be(_testEnumerable.Count());
    }

    [Fact]
    public void Remove_WithKeyAndExistingItem_ShouldRemoveItem() 
    {
        var existingItem = _testEnumerable.First();
        var key = existingItem.GetHashCode();
        var result = _dictionary.Remove(key);

        result.Should().BeTrue();

        _dictionary.Count.Should().Be(_testEnumerable.Count() - 1);
        _dictionary.ContainsKey(key).Should().BeFalse();
    }

    [Fact]
    public void Remove_WithKeyAndNonExistingItem_ShouldNotRemoveItem()
    {
        var newItem = "Orange";
        var key = newItem.GetHashCode();
        var result = _dictionary.Remove(key);

        result.Should().BeFalse();
        _dictionary.Count.Should().Be(_testEnumerable.Count());
    }

    [Fact]
    public void TryGetValue_WhenKeyExists_ShouldReturnTrueAndSetValue()
    {
        var existingItem = _testEnumerable.First();
        var key = existingItem.GetHashCode();
        var result = _dictionary.TryGetValue(key, out var value);

        result.Should().BeTrue();
        value.Should().Be(existingItem);
    }

    [Fact]
    public void TryGetValue_WhenKeyDoesNotExist_ShouldReturnFalseAndSetValueToDefault()
    {
        var newItem = "Papaya";
        var key = newItem.GetHashCode();
        var result = _dictionary.TryGetValue(key, out var value);

        result.Should().BeFalse();
        value.Should().BeNull();
    }

    [Fact]
    public void DoesNotContain_WhenItemDoesNotExist_ShouldReturnTrue()
    {
        var newItem = "Quince";
        var result = _dictionary.DoesNotContain(newItem);

        result.Should().BeTrue();
    }

    [Fact]
    public void DoesNotContain_WhenItemExists_ShouldReturnFalse()
    {
        var existingItem = _testEnumerable.First();
        var result = _dictionary.DoesNotContain(existingItem);

        result.Should().BeFalse();
    }
}
