using System.Collections.Generic;

namespace TenjinX.Interfaces.Collections;

/// <summary>
/// A <see cref="IDictionary{TKey, TValue}"/> interface that uses the hashcode of the instance as the key.
/// </summary>
public interface ITenjinHashCodeDictionary<T> : IDictionary<int, T> where T : notnull
{
    /// <summary>
    /// Gets the instance in the dictionary using the hashcode of the instance.
    /// </summary>
    T this[T key] { get; set; }

    /// <summary>
    /// Attempts to add an instance to the dictionary using the hashcode of the instance.
    /// </summary>
    bool TryAdd(T item);

    /// <summary>
    /// Adds an instance to the dictionary using the hashcode of the instance.
    /// </summary>
    void Add(T item);

    /// <summary>
    /// Determines whether the dictionary contains an instance using the hashcode of the instance.
    /// </summary>
    bool Contains(T item);

    /// <summary>
    /// Determines whether the dictionary does not contain an instance using the hashcode of the instance.
    /// </summary>
    bool DoesNotContain(T item);

    /// <summary>
    /// Copies the contents of the dictionary to another <see cref="ITenjinHashCodeDictionary{T}"/>.
    /// </summary>
    void CopyTo(ITenjinHashCodeDictionary<T> destination);

    /// <summary>
    /// Attempts to remove an instance from the dictionary using the hashcode of the instance.
    /// </summary>
    bool Remove(T item);
}