using System;
using System.Collections.Generic;
using System.Linq;
using TenjinX.Implementations.Comparers;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of extension methods for <see cref="IList{T}"/> instances.
/// </summary>
public static class ListExtensions
{
    /// <summary>
    /// Removes an item at a specific index from an <see cref="IList{T}"/> instance.
    /// </summary>
    public static IList<T> RemoveRangeAt<T>(this IList<T> list, params int[] indexes)
    {
        var sortedIndexes = indexes.OrderByDescending(i => i);

        foreach (var index in sortedIndexes)
        {
            list.RemoveAt(index);
        }

        return list;
    }

    /// <summary>
    /// Performs a binary insert of an item into an <see cref="IList{T}"/> instance using the default comparer.
    /// </summary>
    public static int BinaryInsert<T>
    (
        this IList<T> list,
        T item
    )
    {
        return BinaryInsert(list, item, Comparer<T>.Default);
    }

    /// <summary>
    /// Performs a binary insert of an item into an <see cref="IList{T}"/> instance using a comparison function.
    /// </summary>
    public static int BinaryInsert<T>
    (
        this IList<T> list,
        T item,
        Func<T, T, int> comparerFunc
    )
    {
        var comparer = new TenjinFunctionComparer<T>(comparerFunc);

        return BinaryInsert(list, item, comparer);
    }

    /// <summary>
    /// Performs a binary insert of an item into an <see cref="IList{T}"/> instance using a specified comparer.
    /// </summary>
    public static int BinaryInsert<T>
    (
        this IList<T> list,
        T item,
        IComparer<T> comparer
    )
    {
        var array = list.ToArray();
        var binaryIndex = Array.BinarySearch(array, item, comparer);

        if (binaryIndex < 0)
        {
            binaryIndex = ~binaryIndex;
        }

        list.Insert(binaryIndex, item);

        return binaryIndex;
    }
}
