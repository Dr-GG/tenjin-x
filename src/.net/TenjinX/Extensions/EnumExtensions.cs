using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TenjinX.Exceptions;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of extension methods for working with enums.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Gets the flagged enum values from a bitwise enum.
    /// </summary>
    public static IEnumerable<TEnum> GetFlags<TEnum>(this TEnum value) where TEnum : struct, Enum
    {
        return
        [
            .. Enum
            .GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .Where(flag => flag.GetHashCode() > 0 && value.HasFlag(flag))
        ];
    }

    /// <summary>
    /// Merges a collection of bitwise enum flags into a single enum value.
    /// </summary>
    public static TEnum MergeFlags<TEnum>(this IEnumerable<TEnum> flags) where TEnum : struct, Enum
    {
        ulong result = 0;

        foreach (var flag in flags)
        {
            result |= Convert.ToUInt64(flag);
        }

        return (TEnum)Enum.ToObject(typeof(TEnum), result);
    }
}
