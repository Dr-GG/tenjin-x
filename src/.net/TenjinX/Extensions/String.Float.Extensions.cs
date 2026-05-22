using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of <see cref="string"/> extension methods for providing <see cref="float"/> operations.
/// </summary>
public static class StringFloatExtensions
{
    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="float"/>.
    /// </summary>
    public static float ParseAsFloat(this string value)
    {
        return float.Parse(value);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="float"/> using the specified <see cref="NumberStyles"/>.
    /// </summary>
    public static float ParseAsFloat(this string value, NumberStyles style)
    {
        return float.Parse(value, style);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="float"/> using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    public static float ParseAsFloat(this string value, IFormatProvider provider)
    {
        return float.Parse(value, provider);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="float"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/>.
    /// </summary>
    public static float ParseAsFloat(this string value, NumberStyles style, IFormatProvider provider)
    {
        return float.Parse(value, style, provider);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="float"/>.
    /// </summary>
    public static float? ParseAsNullableFloat
    (
        this string? value,
        float? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (float.TryParse(value, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="float"/> using the specified <see cref="NumberStyles"/>.
    /// </summary>
    public static float? ParseAsNullableFloat
    (
        this string? value,
        NumberStyles style,
        float? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (float.TryParse(value, style, CultureInfo.CurrentCulture, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="float"/> using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    public static float? ParseAsNullableFloat
    (
        this string? value,
        IFormatProvider provider,
        float? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }
        if (float.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, provider, out var result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="float"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/>.
    /// </summary>
    public static float? ParseAsNullableFloat
    (
        this string? value,
        NumberStyles style,
        IFormatProvider provider,
        float? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (float.TryParse(value, style, provider, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="float"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsFloat(this string value, out float result)
    {
        return float.TryParse(value, out result);
    }

    /// <summary>
    /// Attemps to parse a <see cref="string"/> to a <see cref="float"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsFloat(this string value, NumberStyles style, out float result)
    {
        return float.TryParse(value, style, CultureInfo.CurrentCulture, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="float"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsFloat(this string value, IFormatProvider provider, out float result)
    {
        return float.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="float"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsFloat(this string value, NumberStyles style, IFormatProvider provider, out float result)
    {
        return float.TryParse(value, style, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="float"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableFloat
    (
        [NotNullWhen(true)] this string? value,
        [NotNullWhen(true)] out float? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!float.TryParse(value, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="float"/> using the specified <see cref="NumberStyles"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableFloat
    (
        [NotNullWhen(true)] this string? value,
        NumberStyles style,
        [NotNullWhen(true)] out float? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!float.TryParse(value, style, CultureInfo.CurrentCulture, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="float"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableFloat
    (
        [NotNullWhen(true)] this string? value,
        IFormatProvider provider,
        [NotNullWhen(true)] out float? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!float.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, provider, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="float"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableFloat
    (
        [NotNullWhen(true)] this string? value,
        NumberStyles style,
        IFormatProvider provider,
        [NotNullWhen(true)] out float? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!float.TryParse(value, style, provider, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="float"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsFloat(this string value, out float result)
    {
        return !float.TryParse(value, out result);
    }

    /// <summary>
    /// Attemps to parse a <see cref="string"/> to a <see cref="float"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsFloat(this string value, NumberStyles style, out float result)
    {
        return !float.TryParse(value, style, CultureInfo.CurrentCulture, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="float"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsFloat(this string value, IFormatProvider provider, out float result)
    {
        return !float.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="float"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsFloat(this string value, NumberStyles style, IFormatProvider provider, out float result)
    {
        return !float.TryParse(value, style, provider, out result);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="float"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableFloat
    (
        [NotNullWhen(false)] this string? value,
        [NotNullWhen(false)] out float? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!float.TryParse(value, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="float"/> using the specified <see cref="NumberStyles"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableFloat
    (
        [NotNullWhen(false)] this string? value,
        NumberStyles style,
        [NotNullWhen(false)] out float? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!float.TryParse(value, style, CultureInfo.CurrentCulture, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="float"/> using the specified <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableFloat
    (
        [NotNullWhen(false)] this string? value,
        IFormatProvider provider,
        [NotNullWhen(false)] out float? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!float.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, provider, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="float"/> using the specified <see cref="NumberStyles"/> and <see cref="IFormatProvider"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableFloat
    (
        [NotNullWhen(false)] this string? value,
        NumberStyles style,
        IFormatProvider provider,
        [NotNullWhen(false)] out float? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!float.TryParse(value, style, provider, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }
}
