using System;
using System.Diagnostics.CodeAnalysis;
using TenjinX.Exceptions;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of extension methods for parsing strings as enums.
/// </summary>
public static class StringEnumExtensions
{
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

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> as an enum of type <typeparamref name="TEnum"/>.
    /// </summary>
    public static bool TryParseAsNullableEnum<TEnum>
    (
        [NotNullWhen(true)] this string? value,
        [NotNullWhen(true)] out TEnum? result,
        bool ignoreCase = true
    ) where TEnum : struct, Enum
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!Enum.TryParse<TEnum>(value, ignoreCase, out var finalResult))
        {
            return false;
        }

        result = finalResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> as an enum of type <typeparamref name="TEnum"/>, returning true if the parsing fails.
    /// </summary>
    public static bool TryFailParseAsEnum<TEnum>
    (
        this string value,
        out TEnum result,
        bool ignoreCase = true
    ) where TEnum : struct, Enum
    {
        if (Enum.TryParse(value, ignoreCase, out result))
        {
            return false;
        }

        result = default;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> as an enum of type <typeparamref name="TEnum"/>, returning true if the parsing fails.
    /// </summary>
    public static bool TryFailParseAsNullableEnum<TEnum>
    (
        [NotNullWhen(false)] this string? value,
        [NotNullWhen(false)] out TEnum? result,
        bool ignoreCase = true
    ) where TEnum : struct, Enum
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!Enum.TryParse<TEnum>(value, ignoreCase, out var finalResult))
        {
            return true;
        }

        result = finalResult;

        return false;
    }
}