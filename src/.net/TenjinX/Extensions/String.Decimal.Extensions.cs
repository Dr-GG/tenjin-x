using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of <see cref="string"/> extension methods for providing <see cref="decimal"/> operations.
/// </summary>
public static class StringDecimalExtensions
{
    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="decimal"/>.
    /// </summary>
    public static decimal ParseAsDecimal(this string value)
    {
        return decimal.Parse(value);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="NumberStyles"/>.
    /// </summary>
    public static decimal ParseAsDecimal(this string value, NumberStyles style)
    {
        return decimal.Parse(value, style);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    public static decimal ParseAsDecimal(this string value, IFormatProvider provider)
    {
        return decimal.Parse(value, provider);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/>.
    /// </summary>
    public static decimal ParseAsDecimal(this string value, NumberStyles style, IFormatProvider provider)
    {
        return decimal.Parse(value, style, provider);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="decimal"/>.
    /// </summary>
    public static decimal? ParseAsNullableDecimal
    (
        this string? value,
        decimal? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (decimal.TryParse(value, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="NumberStyles"/>.
    /// </summary>
    public static decimal? ParseAsNullableDecimal
    (
        this string? value,
        NumberStyles style,
        decimal? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (decimal.TryParse(value, style, CultureInfo.CurrentCulture, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    public static decimal? ParseAsNullableDecimal
    (
        this string? value,
        IFormatProvider provider,
        decimal? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }
        if (decimal.TryParse(value, NumberStyles.Number, provider, out var result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/>.
    /// </summary>
    public static decimal? ParseAsNullableDecimal
    (
        this string? value,
        NumberStyles style,
        IFormatProvider provider,
        decimal? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (decimal.TryParse(value, style, provider, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="decimal"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsDecimal(this string value, out decimal result)
    {
        return decimal.TryParse(value, out result);
    }

    /// <summary>
    /// Attemps to parse a <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsDecimal(this string value, NumberStyles style, out decimal result)
    {
        return decimal.TryParse(value, style, CultureInfo.CurrentCulture, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsDecimal(this string value, IFormatProvider provider, out decimal result)
    {
        return decimal.TryParse(value, NumberStyles.Number, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsDecimal(this string value, NumberStyles style, IFormatProvider provider, out decimal result)
    {
        return decimal.TryParse(value, style, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="decimal"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableDecimal
    (
        [NotNullWhen(true)] this string? value,
        [NotNullWhen(true)] out decimal? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!decimal.TryParse(value, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="NumberStyles"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableDecimal
    (
        [NotNullWhen(true)] this string? value,
        NumberStyles style,
        [NotNullWhen(true)] out decimal? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!decimal.TryParse(value, style, CultureInfo.CurrentCulture, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableDecimal
    (
        [NotNullWhen(true)] this string? value,
        IFormatProvider provider,
        [NotNullWhen(true)] out decimal? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!decimal.TryParse(value, NumberStyles.Number, provider, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableDecimal
    (
        [NotNullWhen(true)] this string? value,
        NumberStyles style,
        IFormatProvider provider,
        [NotNullWhen(true)] out decimal? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!decimal.TryParse(value, style, provider, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="decimal"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsDecimal(this string value, out decimal result)
    {
        return !decimal.TryParse(value, out result);
    }

    /// <summary>
    /// Attemps to parse a <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsDecimal(this string value, NumberStyles style, out decimal result)
    {
        return !decimal.TryParse(value, style, CultureInfo.CurrentCulture, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsDecimal(this string value, IFormatProvider provider, out decimal result)
    {
        return !decimal.TryParse(value, NumberStyles.Number, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsDecimal(this string value, NumberStyles style, IFormatProvider provider, out decimal result)
    {
        return !decimal.TryParse(value, style, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="decimal"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableDecimal
    (
        [NotNullWhen(false)] this string? value,
        [NotNullWhen(false)] out decimal? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!decimal.TryParse(value, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="NumberStyles"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableDecimal
    (
        [NotNullWhen(false)] this string? value,
        NumberStyles style,
        [NotNullWhen(false)] out decimal? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!decimal.TryParse(value, style, CultureInfo.CurrentCulture, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableDecimal
    (
        [NotNullWhen(false)] this string? value,
        IFormatProvider provider,
        [NotNullWhen(false)] out decimal? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!decimal.TryParse(value, NumberStyles.Number, provider, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="decimal"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableDecimal
    (
        [NotNullWhen(false)] this string? value,
        NumberStyles style,
        IFormatProvider provider,
        [NotNullWhen(false)] out decimal? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!decimal.TryParse(value, style, provider, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }
}
