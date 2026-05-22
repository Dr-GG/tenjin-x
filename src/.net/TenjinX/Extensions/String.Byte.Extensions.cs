using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of <see cref="string"/> extension methods for providing <see cref="byte"/> operations.
/// </summary>
public static class StringByteExtensions
{
    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="byte"/>.
    /// </summary>
    public static byte ParseAsByte(this string value)
    {
        return byte.Parse(value);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="NumberStyles"/>.
    /// </summary>
    public static byte ParseAsByte(this string value, NumberStyles style)
    {
        return byte.Parse(value, style);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    public static byte ParseAsByte(this string value, IFormatProvider provider)
    {
        return byte.Parse(value, provider);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/>.
    /// </summary>
    public static byte ParseAsByte(this string value, NumberStyles style, IFormatProvider provider)
    {
        return byte.Parse(value, style, provider);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="byte"/>.
    /// </summary>
    public static byte? ParseAsNullableByte
    (
        this string? value,
        byte? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (byte.TryParse(value, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="NumberStyles"/>.
    /// </summary>
    public static byte? ParseAsNullableByte
    (
        this string? value,
        NumberStyles style,
        byte? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (byte.TryParse(value, style, CultureInfo.CurrentCulture, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    public static byte? ParseAsNullableByte
    (
        this string? value,
        IFormatProvider provider,
        byte? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }
        if (byte.TryParse(value, NumberStyles.Integer, provider, out var result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/>.
    /// </summary>
    public static byte? ParseAsNullableByte
    (
        this string? value,
        NumberStyles style,
        IFormatProvider provider,
        byte? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (byte.TryParse(value, style, provider, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="byte"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsByte(this string value, out byte result)
    {
        return byte.TryParse(value, out result);
    }

    /// <summary>
    /// Attemps to parse a <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsByte(this string value, NumberStyles style, out byte result)
    {
        return byte.TryParse(value, style, CultureInfo.CurrentCulture, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsByte(this string value, IFormatProvider provider, out byte result)
    {
        return byte.TryParse(value, NumberStyles.Integer, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsByte(this string value, NumberStyles style, IFormatProvider provider, out byte result)
    {
        return byte.TryParse(value, style, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="byte"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableByte
    (
        [NotNullWhen(true)] this string? value,
        [NotNullWhen(true)] out byte? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!byte.TryParse(value, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="NumberStyles"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableByte
    (
        [NotNullWhen(true)] this string? value,
        NumberStyles style,
        [NotNullWhen(true)] out byte? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!byte.TryParse(value, style, CultureInfo.CurrentCulture, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableByte
    (
        [NotNullWhen(true)] this string? value,
        IFormatProvider provider,
        [NotNullWhen(true)] out byte? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!byte.TryParse(value, NumberStyles.Integer, provider, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableByte
    (
        [NotNullWhen(true)] this string? value,
        NumberStyles style,
        IFormatProvider provider,
        [NotNullWhen(true)] out byte? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!byte.TryParse(value, style, provider, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="byte"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsByte(this string value, out byte result)
    {
        return !byte.TryParse(value, out result);
    }

    /// <summary>
    /// Attemps to parse a <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsByte(this string value, NumberStyles style, out byte result)
    {
        return !byte.TryParse(value, style, CultureInfo.CurrentCulture, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsByte(this string value, IFormatProvider provider, out byte result)
    {
        return !byte.TryParse(value, NumberStyles.Integer, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsByte(this string value, NumberStyles style, IFormatProvider provider, out byte result)
    {
        return !byte.TryParse(value, style, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="byte"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableByte
    (
        [NotNullWhen(false)] this string? value,
        [NotNullWhen(false)] out byte? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!byte.TryParse(value, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="NumberStyles"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableByte
    (
        [NotNullWhen(false)] this string? value,
        NumberStyles style,
        [NotNullWhen(false)] out byte? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!byte.TryParse(value, style, CultureInfo.CurrentCulture, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableByte
    (
        [NotNullWhen(false)] this string? value,
        IFormatProvider provider,
        [NotNullWhen(false)] out byte? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!byte.TryParse(value, NumberStyles.Integer, provider, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="byte"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableByte
    (
        [NotNullWhen(false)] this string? value,
        NumberStyles style,
        IFormatProvider provider,
        [NotNullWhen(false)] out byte? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!byte.TryParse(value, style, provider, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }
}
