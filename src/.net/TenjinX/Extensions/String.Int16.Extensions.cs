using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of <see cref="string"/> extension methods for providing <see cref="short"/> operations.
/// </summary>
public static class StringInt16Extensions
{
    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="short"/>.
    /// </summary>
    public static short ParseAsInt16(this string value)
    {
        return short.Parse(value);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="short"/> using the specified <see cref="NumberStyles"/>.
    /// </summary>
    public static short ParseAsInt16(this string value, NumberStyles style)
    {
        return short.Parse(value, style);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="short"/> using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    public static short ParseAsInt16(this string value, IFormatProvider provider)
    {
        return short.Parse(value, provider);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="short"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/>.
    /// </summary>
    public static short ParseAsInt16(this string value, NumberStyles style, IFormatProvider provider)
    {
        return short.Parse(value, style, provider);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="short"/>.
    /// </summary>
    public static short? ParseAsNullableInt16
    (
        this string? value,
        short? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (short.TryParse(value, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="short"/> using the specified <see cref="NumberStyles"/>.
    /// </summary>
    public static short? ParseAsNullableInt16
    (
        this string? value,
        NumberStyles style,
        short? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (short.TryParse(value, style, CultureInfo.CurrentCulture, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="short"/> using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    public static short? ParseAsNullableInt16
    (
        this string? value,
        IFormatProvider provider,
        short? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }
        if (short.TryParse(value, NumberStyles.Integer, provider, out var result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="short"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/>.
    /// </summary>
    public static short? ParseAsNullableInt16
    (
        this string? value,
        NumberStyles style,
        IFormatProvider provider,
        short? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (short.TryParse(value, style, provider, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="short"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsInt16(this string value, out short result)
    {
        return short.TryParse(value, out result);
    }

    /// <summary>
    /// Attemps to parse a <see cref="string"/> to a <see cref="short"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsInt16(this string value, NumberStyles style, out short result)
    {
        return short.TryParse(value, style, CultureInfo.CurrentCulture, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="short"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsInt16(this string value, IFormatProvider provider, out short result)
    {
        return short.TryParse(value, NumberStyles.Integer, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="short"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsInt16(this string value, NumberStyles style, IFormatProvider provider, out short result)
    {
        return short.TryParse(value, style, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="short"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableInt16
    (
        [NotNullWhen(true)] this string? value,
        [NotNullWhen(true)] out short? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!short.TryParse(value, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="short"/> using the specified <see cref="NumberStyles"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableInt16
    (
        [NotNullWhen(true)] this string? value,
        NumberStyles style,
        [NotNullWhen(true)] out short? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!short.TryParse(value, style, CultureInfo.CurrentCulture, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="short"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableInt16
    (
        [NotNullWhen(true)] this string? value,
        IFormatProvider provider,
        [NotNullWhen(true)] out short? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!short.TryParse(value, NumberStyles.Integer, provider, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="short"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableInt16
    (
        [NotNullWhen(true)] this string? value,
        NumberStyles style,
        IFormatProvider provider,
        [NotNullWhen(true)] out short? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!short.TryParse(value, style, provider, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="short"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsInt16(this string value, out short result)
    {
        return !short.TryParse(value, out result);
    }

    /// <summary>
    /// Attemps to parse a <see cref="string"/> to a <see cref="short"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsInt16(this string value, NumberStyles style, out short result)
    {
        return !short.TryParse(value, style, CultureInfo.CurrentCulture, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="short"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsInt16(this string value, IFormatProvider provider, out short result)
    {
        return !short.TryParse(value, NumberStyles.Integer, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="short"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsInt16(this string value, NumberStyles style, IFormatProvider provider, out short result)
    {
        return !short.TryParse(value, style, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="short"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableInt16
    (
        [NotNullWhen(false)] this string? value,
        [NotNullWhen(false)] out short? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!short.TryParse(value, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="short"/> using the specified <see cref="NumberStyles"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableInt16
    (
        [NotNullWhen(false)] this string? value,
        NumberStyles style,
        [NotNullWhen(false)] out short? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!short.TryParse(value, style, CultureInfo.CurrentCulture, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="short"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableInt16
    (
        [NotNullWhen(false)] this string? value,
        IFormatProvider provider,
        [NotNullWhen(false)] out short? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!short.TryParse(value, NumberStyles.Integer, provider, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="short"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableInt16
    (
        [NotNullWhen(false)] this string? value,
        NumberStyles style,
        IFormatProvider provider,
        [NotNullWhen(false)] out short? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!short.TryParse(value, style, provider, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }
}
