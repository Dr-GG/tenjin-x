using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of extension methods for the <see cref="IDictionary{TKey, TValue}"/> interface.
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    /// A method that is used to determine if a key is not contained within an <see cref="IDictionary{TKey, TValue}"/> interface.
    /// </summary>
    public static bool DoesNotContainKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
    {
        return !dictionary.ContainsKey(key);
    }

    /// <summary>
    /// Attempts to add a key/value pair to the <see cref="IDictionary{TKey, TValue}"/> interface if the key does not already exist.
    /// </summary>
    public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueCallback)
    {
        if (dictionary.ContainsKey(key))
        {
            return false;
        }

        var value = valueCallback();

        dictionary.Add(key, value);

        return true;
    }

    /// <summary>
    /// Attempts to add a key/value pair to the <see cref="IDictionary{TKey, TValue}"/> interface if the key does not already exist.
    /// </summary>
    public static async Task<bool> TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<Task<TValue>> valueCallback)
    {
        if (dictionary.ContainsKey(key))
        {
            return false;
        }

        var value = await valueCallback();

        dictionary.Add(key, value);

        return true;
    }
}