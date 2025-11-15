using System.Collections.Generic;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of extension methods for <see cref="ICollection{T}"/> instances.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Adds a range of items to an <see cref="ICollection{T}"/> instance.
    /// </summary>
    public static ICollection<T> AddRange<T>(this ICollection<T> collection, params T[] items)
    {
        foreach (var item in items)
        {
            collection.Add(item);
        }

        return collection;
    }

    /// <summary>
    /// Removes a range of items from an <see cref="ICollection{T}"/> instance.
    /// </summary>
    public static ICollection<T> RemoveRange<T>(this ICollection<T> collection, params T[] items)
    {
        foreach (var item in items)
        {
            collection.Remove(item);
        }

        return collection;
    }
}
