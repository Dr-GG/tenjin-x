using System.Diagnostics.CodeAnalysis;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of <see cref="string"/> extension methods for providing <see cref="bool"/> operations.
/// </summary>
public static class StringBooleanExtensions
{
    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="bool"/>.
    /// </summary>
    public static bool ParseAsBoolean(this string value)
    {
        return bool.Parse(value);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="bool"/>.
    /// </summary>
    public static bool? ParseAsNullableBoolean
    (
        this string? value,
        bool? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (bool.TryParse(value, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="bool"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsBoolean(this string value, out bool result)
    {
        return bool.TryParse(value, out result);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="bool"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableBoolean
    (
        [NotNullWhen(true)] this string? value,
        [NotNullWhen(true)] out bool? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!bool.TryParse(value, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="bool"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsBoolean(this string value, out bool result)
    {
        return !bool.TryParse(value, out result);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="bool"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableBoolean
    (
        [NotNullWhen(false)] this string? value,
        [NotNullWhen(false)] out bool? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!bool.TryParse(value, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }
}
