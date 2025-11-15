using System.Collections;
using System.Collections.Generic;
using TenjinX.Interfaces.Collections;

namespace TenjinX.Implementations.Collections;

/// <summary>
/// The default implementation of the IHashCodeDictionary instance.
/// </summary>
public class TenjinHashCodeDictionary<T> : ITenjinHashCodeDictionary<T> where T : notnull
{
    private readonly IDictionary<int, T> _dictionary;

    /// <summary>
    /// Creates a new default instance.
    /// </summary>
    public TenjinHashCodeDictionary()
    {
        _dictionary = new Dictionary<int, T>();
    }

    /// <summary>
    /// Creates a new instance from an existing collection.
    /// </summary>
    /// <param name="collection"></param>
    public TenjinHashCodeDictionary(IEnumerable<T> collection)
    {
        _dictionary = new Dictionary<int, T>();

        foreach (var item in collection)
        {
            _dictionary[item.GetHashCode()] = item;
        }
    }

    /// <summary>
    /// Creates a new instance from an existing dictionary.
    /// </summary>
    public TenjinHashCodeDictionary(IDictionary<int, T> dictionary)
    {
        _dictionary = new Dictionary<int, T>(dictionary);
    }

    /// <summary>
    /// Creates a new instance from an existing collection.
    /// </summary>
    public TenjinHashCodeDictionary(IEnumerable<KeyValuePair<int, T>> collection)
    {
        _dictionary = new Dictionary<int, T>(collection);
    }

    /// <inheritdoc />
    public bool IsReadOnly => _dictionary.IsReadOnly;

    /// <inheritdoc />
    public int Count => _dictionary.Count;

    /// <inheritdoc />
    public ICollection<int> Keys => _dictionary.Keys;

    /// <inheritdoc />
    public ICollection<T> Values => _dictionary.Values;

    /// <inheritdoc />
    public T this[int key]
    {
        get => _dictionary[key];
        set => _dictionary[key] = value;
    }

    /// <inheritdoc />
    public T this[T key]
    {
        get => _dictionary[key.GetHashCode()];
        set => _dictionary[key.GetHashCode()] = value;
    }

    /// <inheritdoc />
    public IEnumerator<KeyValuePair<int, T>> GetEnumerator()
    {
        return _dictionary.GetEnumerator();
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return _dictionary.GetEnumerator();
    }

    /// <inheritdoc />
    public bool TryAdd(T item)
    {
        return _dictionary.TryAdd(item.GetHashCode(), item);
    }

    /// <inheritdoc />
    public void Add(int key, T value)
    {
        _dictionary.Add(key, value);
    }

    /// <inheritdoc />
    public void Add(KeyValuePair<int, T> item)
    {
        _dictionary.Add(item);
    }

    /// <inheritdoc />
    public void Add(T item)
    {
        Add(item.GetHashCode(), item);
    }

    /// <inheritdoc />
    public void Clear()
    {
        _dictionary.Clear();
    }

    /// <inheritdoc />
    public bool Contains(KeyValuePair<int, T> item)
    {
        return _dictionary.Contains(item);
    }

    /// <inheritdoc />
    public bool Contains(T item)
    {
        return _dictionary.ContainsKey(item.GetHashCode());
    }

    /// <inheritdoc />
    public bool DoesNotContain(T item)
    {
        return !Contains(item);
    }

    /// <inheritdoc />
    public bool ContainsKey(int key)
    {
        return _dictionary.ContainsKey(key);
    }

    /// <inheritdoc />
    public void CopyTo(KeyValuePair<int, T>[] array, int arrayIndex)
    {
        _dictionary.CopyTo(array, arrayIndex);
    }

    /// <inheritdoc />
    public void CopyTo(ITenjinHashCodeDictionary<T> destination)
    {
        using var enumerator = _dictionary.GetEnumerator();

        while (enumerator.MoveNext())
        {
            var (key, value) = enumerator.Current;

            destination.Add(key, value);
        }
    }

    /// <inheritdoc />
    public bool Remove(KeyValuePair<int, T> item)
    {
        return _dictionary.Remove(item);
    }

    /// <inheritdoc />
    public bool Remove(T item)
    {
        return _dictionary.Remove(item.GetHashCode());
    }

    /// <inheritdoc />
    public bool Remove(int key)
    {
        return _dictionary.Remove(key);
    }

    /// <inheritdoc />
    public bool TryGetValue(int key, out T value)
    {
#pragma warning disable CS8601 // Possible null reference assignment.
        return _dictionary.TryGetValue(key, out value);
#pragma warning restore CS8601 // Possible null reference assignment.
    }
}