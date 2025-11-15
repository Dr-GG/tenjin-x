using System;
using System.Collections.Generic;
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
        var result = 0;

        flags
            .Select(flag => flag.GetHashCode())
            .ForEach(flag =>
            {
                result |= flag;
            });

        return (TEnum)(object)result;
    }

    /// <summary>
    /// Attempts parse a <see cref="string"/> as an enum of type <typeparamref name="TEnum"/>.
    /// </summary>
    /// <exception cref="TenjinException">
    /// Thrown when the provided value cannot be parsed as the specified enum type.
    /// </exception>
    public static TEnum ParseAsEnum<TEnum>
    (
        this string value,
        bool ignoreCase = true
    ) where TEnum : struct, Enum
    {
        if (Enum.TryParse<TEnum>(value, ignoreCase, out var result))
        {
            return result;
        }

        throw new TenjinException($"An invalid enum value '{value}' was provided for {typeof(TEnum).Name}.");
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> as a nullable enum of type <typeparamref name="TEnum"/>.
    /// </summary>
    public static TEnum? ParseAsNullableEnum<TEnum>
    (
        this string? value,
        TEnum? defaultValue = null,
        bool ignoreCase = true
    ) where TEnum : struct, Enum
    {
        if (Enum.TryParse<TEnum>(value, ignoreCase, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to convert a <see cref="string"/> to an enum of type <typeparamref name="TEnum"/>.
    /// </summary>
    public static bool TryParseAsEnum<TEnum>
    (
        this string value,
        out TEnum result,
        bool ignoreCase = true
    ) where TEnum : struct, Enum
    {
        return Enum.TryParse(value, ignoreCase, out result);
    }
}
