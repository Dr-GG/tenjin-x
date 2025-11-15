using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TenjinX.Implementations.Comparers;
using TenjinX.Models.Enumerables;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of extension methods for the <see cref="IEnumerable{T}"/> interface.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Enumerates an <see cref="IEnumerable{T}"/> to an <see cref="IList{T}"/> instance.
    /// </summary>
    public static IList<T> EnumerateToList<T>(this IEnumerable<T> enumerable)
    {
        if (enumerable is List<T> list)
        {
            return list;
        }

        return [.. enumerable];
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> contains no items.
    /// </summary>
    public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
    {
        return !enumerable.Any();
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> contains at least one item.
    /// </summary>
    public static bool IsNotEmpty<T>(this IEnumerable<T> enumerable)
    {
        return enumerable.Any();
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> is not null and contains at least one item.
    /// </summary>
    public static bool IsNotNullOrEmpty<T>([NotNullWhen(true)] this IEnumerable<T>? enumerable)
    {
        return enumerable?.Any() ?? false;
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> is null or contains no items.
    /// </summary>
    public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? enumerable)
    {
        return !enumerable?.Any() ?? true;
    }

    /// <summary>
    /// Determines the last index of a specific item in an <see cref="IEnumerable{T}"/> instance.
    /// </summary>
    public static int LastIndexOf<T>(this IEnumerable<T> enumerable, T item)
    {
        var list = enumerable.ToList();

        return list.FindLastIndex(i => EqualityComparer<T>.Default.Equals(i, item));
    }

    /// <summary>
    /// Determines the last index of an item in an <see cref="IEnumerable{T}"/> instance that matches a given predicate.
    /// </summary>
    public static int LastIndexOf<T>(this IEnumerable<T> enumerable, Predicate<T> match)
    {
        var list = enumerable.ToList();

        return list.FindLastIndex(match);
    }

    /// <summary>
    /// Attempts to find the index of an item in an <see cref="IEnumerable{T}"/> instance that matches a given predicate.
    /// </summary>
    public static int IndexOf<T>(this IEnumerable<T> enumerable, Predicate<T> match)
    {
        var list = enumerable.ToList();

        return list.FindIndex(match);
    }

    /// <summary>
    /// Gets the last index of an <see cref="IEnumerable{T}"/> instance.
    /// </summary>
    public static int LastIndex<T>(this IEnumerable<T> enumerable)
    {
        return enumerable.Count() - 1;
    }

    /// <summary>
    /// Converts an <see cref="IEnumerable{T}"/> to a joined string with a specified separator.
    /// </summary>
    public static string ToJoinedString<T>(this IEnumerable<T> enumerable, string separator)
    {
        return string.Join(separator, enumerable);
    }

    /// <summary>
    /// Transforms an IEnumerable into a number of batches of equal or near-equal size.
    /// </summary>
    public static IEnumerable<IEnumerable<T>> PartitionInto<T>(this IEnumerable<T> enumerable, int numberOfPartitions)
    {
        switch (numberOfPartitions)
        {
            case < 1:
                throw new ArgumentOutOfRangeException(nameof(numberOfPartitions), "Argument cannot be zero or less.");
            case 1:
                return [enumerable];
        }

        var list = enumerable.ToList();

        if (list.IsEmpty())
        {
            return [];
        }

        var finalNumberOfPartitions = Math.Min(numberOfPartitions, list.Count);
        var batchSize = (int)Math.Floor(list.Count / (double)finalNumberOfPartitions);
        var lastBatchSize = batchSize + list.Count % finalNumberOfPartitions;
        var batches = new List<IEnumerable<T>>(finalNumberOfPartitions);

        for (var i = 0; i < finalNumberOfPartitions; i++)
        {
            var index = i * batchSize;
            var arrayBatchSize = i == finalNumberOfPartitions - 1
                ? lastBatchSize
                : batchSize;
            var batch = new T[arrayBatchSize];

            list.CopyTo(index, batch, 0, arrayBatchSize);

            batches.Add(batch);
        }

        return batches;
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> contains a specific item that matches a given predicate.
    /// </summary>
    public static bool Contains<T>(this IEnumerable<T> enumerable, Predicate<T> match)
    {
        return enumerable.Any(item => match(item));
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> contains all items from another <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static bool ContainsAll<T>(this IEnumerable<T> enumerable, IEnumerable<T> items)
    {
        return items.All(item => enumerable.Contains(item));
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> contains all items that match a given predicate.
    /// </summary>
    public static bool ContainsAll<T>(this IEnumerable<T> enumerable, Predicate<T> match)
    {
        return enumerable.All(item => match(item));
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> contains any items from another <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static bool ContainsAny<T>(this IEnumerable<T> enumerable, IEnumerable<T> items)
    {
        return items.Any(item => enumerable.Contains(item));
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> contains any items that match a given predicate.
    /// </summary>
    public static bool ContainsAny<T>(this IEnumerable<T> enumerable, Predicate<T> match)
    {
        return enumerable.Any(item => match(item));
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> does not contain a specific item.
    /// </summary>
    public static bool DoesNotContain<T>(this IEnumerable<T> enumerable, T item)
    {
        return !enumerable.Contains(item);
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> does not contain any items that match a given predicate.
    /// </summary>
    public static bool DoesNotContain<T>(this IEnumerable<T> enumerable, Predicate<T> match)
    {
        return !enumerable.Any(item => match(item));
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> does not contain all items from another <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static bool DoesNotContainAny<T>(this IEnumerable<T> enumerable, IEnumerable<T> items)
    {
        return !items.Any(item => enumerable.Contains(item));
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> does not contain any items that match a given predicate.
    /// </summary>
    public static bool DoesNotContainAny<T>(this IEnumerable<T> enumerable, Predicate<T> match)
    {
        return !enumerable.Any(item => match(item));
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> does not contain all items that match a given predicate.
    /// </summary>
    public static bool DoesNotContainAll<T>(this IEnumerable<T> enumerable, IEnumerable<T> items)
    {
        return !items.All(item => enumerable.Contains(item));
    }

    /// <summary>
    /// Determines if an <see cref="IEnumerable{T}"/> does not contain all items that match a given predicate.
    /// </summary>
    public static bool DoesNotContainAll<T>(this IEnumerable<T> enumerable, Predicate<T> match)
    {
        return !enumerable.All(item => match(item));
    }

    /// <summary>
    /// Iterates over an <see cref="IEnumerable{T}"/> with a given action that receives the item.
    /// </summary>
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        foreach (var item in enumerable)
        {
            action(item);
        }

        return enumerable;
    }

    /// <summary>
    /// Iterates over an <see cref="IEnumerable{T}"/> with a given action that receives the index position and the item.
    /// </summary>
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<int, T> action)
    {
        var index = 0;

        foreach (var item in enumerable)
        {
            action(index++, item);
        }

        return enumerable;
    }

    /// <summary>
    /// Iterates over an <see cref="IEnumerable{T}"/> with a given action that receives the loop context and the item.
    /// </summary>
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<TenjinForEachContext, T> action)
    {
        var enumerated = enumerable.EnumerateToList();
        var index = 0;
        var lastIndex = enumerated.LastIndex();
        var context = new TenjinForEachContext();

        foreach (var item in enumerated)
        {
            context.IsFirst = index == 0;
            context.IsLast = index == lastIndex;
            context.IsInBetween = index > 0 && index < lastIndex;
            context.Index = index++;

            action(context, item);
        }

        return enumerable;
    }

    /// <summary>
    /// Performs a binary search for an item in an <see cref="ICollection{T}"/> instance using a comparison function.
    /// </summary>
    public static int BinarySearch<T>
    (
        this IEnumerable<T> enumerable,
        T item,
        Func<T, T, int> comparerFunc
    )
    {
        var comparer = new TenjinFunctionComparer<T>(comparerFunc);

        return BinarySearch(enumerable, item, comparer);
    }

    /// <summary>
    /// Performs a binary search for an item in an <see cref="ICollection{T}"/> instance using a comparison function.
    /// </summary>
    public static int BinarySearch<T>
    (
        this IEnumerable<T> enumerable,
        T item,
        IComparer<T> comparer
    )
    {
        var array = enumerable.ToArray();
        var binaryIndex = Array.BinarySearch(array, item, comparer);

        return binaryIndex;
    }

    /// <summary>
    /// Determines if an <see cref="ICollection{T}"/> contains a specific item using binary search.
    /// </summary>
    public static bool BinarySearchContains<T>(this IEnumerable<T> enumerable, T item) where T : IComparable<T>
    {
        var comparer = Comparer<T>.Default;

        return BinarySearchContains(enumerable, item, comparer);
    }

    /// <summary>
    /// Determines if an <see cref="ICollection{T}"/> contains a specific item using binary search with a comparison function.
    /// </summary>
    public static bool BinarySearchContains<T>
    (
        this IEnumerable<T> enumerable,
        T item,
        Func<T, T, int> comparerFunc
    )
    {
        var comparer = new TenjinFunctionComparer<T>(comparerFunc);

        return BinarySearchContains(enumerable, item, comparer);
    }

    /// <summary>
    /// Determines if an <see cref="ICollection{T}"/> contains a specific item using binary search with a comparer.
    /// </summary>
    public static bool BinarySearchContains<T>
    (
        this IEnumerable<T> enumerable,
        T item,
        IComparer<T> comparer
    )
    {
        var array = enumerable.ToArray();
        var binaryIndex = Array.BinarySearch(array, item, comparer);

        return binaryIndex >= 0;
    }

    /// <summary>
    /// Calculates a hash code for an <see cref="IEnumerable{T}"/> instance based on its items.
    /// </summary>
    public static int GetCollectionHashCode<T>(this IEnumerable<T> enumerable)
    {
        var hashCode = new HashCode();

        foreach (var item in enumerable)
        {
            hashCode.Add(item);
        }

        return hashCode.ToHashCode();
    }
}