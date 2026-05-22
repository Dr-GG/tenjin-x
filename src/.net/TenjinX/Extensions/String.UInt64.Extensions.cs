using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of <see cref="string"/> extension methods for providing <see cref="ulong"/> operations.
/// </summary>
public static class StringUInt64Extensions
{
    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="ulong"/>.
    /// </summary>
    public static ulong ParseAsUInt64(this string value)
    {
        return ulong.Parse(value);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="NumberStyles"/>.
    /// </summary>
    public static ulong ParseAsUInt64(this string value, NumberStyles style)
    {
        return ulong.Parse(value, style);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    public static ulong ParseAsUInt64(this string value, IFormatProvider provider)
    {
        return ulong.Parse(value, provider);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/>.
    /// </summary>
    public static ulong ParseAsUInt64(this string value, NumberStyles style, IFormatProvider provider)
    {
        return ulong.Parse(value, style, provider);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="ulong"/>.
    /// </summary>
    public static ulong? ParseAsNullableUInt64
    (
        this string? value,
        ulong? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (ulong.TryParse(value, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="NumberStyles"/>.
    /// </summary>
    public static ulong? ParseAsNullableUInt64
    (
        this string? value,
        NumberStyles style,
        ulong? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (ulong.TryParse(value, style, CultureInfo.CurrentCulture, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    public static ulong? ParseAsNullableUInt64
    (
        this string? value,
        IFormatProvider provider,
        ulong? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }
        if (ulong.TryParse(value, NumberStyles.Integer, provider, out var result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/>.
    /// </summary>
    public static ulong? ParseAsNullableUInt64
    (
        this string? value,
        NumberStyles style,
        IFormatProvider provider,
        ulong? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (ulong.TryParse(value, style, provider, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="ulong"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsUInt64(this string value, out ulong result)
    {
        return ulong.TryParse(value, out result);
    }

    /// <summary>
    /// Attemps to parse a <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsUInt64(this string value, NumberStyles style, out ulong result)
    {
        return ulong.TryParse(value, style, CultureInfo.CurrentCulture, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsUInt64(this string value, IFormatProvider provider, out ulong result)
    {
        return ulong.TryParse(value, NumberStyles.Integer, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsUInt64(this string value, NumberStyles style, IFormatProvider provider, out ulong result)
    {
        return ulong.TryParse(value, style, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="ulong"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableUInt64
    (
        [NotNullWhen(true)] this string? value,
        [NotNullWhen(true)] out ulong? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!ulong.TryParse(value, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="NumberStyles"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableUInt64
    (
        [NotNullWhen(true)] this string? value,
        NumberStyles style,
        [NotNullWhen(true)] out ulong? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!ulong.TryParse(value, style, CultureInfo.CurrentCulture, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableUInt64
    (
        [NotNullWhen(true)] this string? value,
        IFormatProvider provider,
        [NotNullWhen(true)] out ulong? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!ulong.TryParse(value, NumberStyles.Integer, provider, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableUInt64
    (
        [NotNullWhen(true)] this string? value,
        NumberStyles style,
        IFormatProvider provider,
        [NotNullWhen(true)] out ulong? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!ulong.TryParse(value, style, provider, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="ulong"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsUInt64(this string value, out ulong result)
    {
        return !ulong.TryParse(value, out result);
    }

    /// <summary>
    /// Attemps to parse a <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsUInt64(this string value, NumberStyles style, out ulong result)
    {
        return !ulong.TryParse(value, style, CultureInfo.CurrentCulture, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsUInt64(this string value, IFormatProvider provider, out ulong result)
    {
        return !ulong.TryParse(value, NumberStyles.Integer, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsUInt64(this string value, NumberStyles style, IFormatProvider provider, out ulong result)
    {
        return !ulong.TryParse(value, style, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="ulong"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableUInt64
    (
        [NotNullWhen(false)] this string? value,
        [NotNullWhen(false)] out ulong? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!ulong.TryParse(value, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="NumberStyles"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableUInt64
    (
        [NotNullWhen(false)] this string? value,
        NumberStyles style,
        [NotNullWhen(false)] out ulong? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!ulong.TryParse(value, style, CultureInfo.CurrentCulture, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableUInt64
    (
        [NotNullWhen(false)] this string? value,
        IFormatProvider provider,
        [NotNullWhen(false)] out ulong? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!ulong.TryParse(value, NumberStyles.Integer, provider, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="ulong"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableUInt64
    (
        [NotNullWhen(false)] this string? value,
        NumberStyles style,
        IFormatProvider provider,
        [NotNullWhen(false)] out ulong? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!ulong.TryParse(value, style, provider, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }
}
