using System;
using System.Diagnostics.CodeAnalysis;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of <see cref="string"/> extension methods for providing <see cref="Guid"/> operations.
/// </summary>
public static class StringGuidExtensions
{
    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="Guid"/>.
    /// </summary>
    public static Guid ParseAsGuid(this string value)
    {
        return Guid.Parse(value);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="Guid"/>.
    /// </summary>
    public static Guid? ParseAsNullableGuid
    (
        this string? value,
        Guid? defaultValue = null
    )
    {
        if (value.IsNullOrEmpty())
        {
            return defaultValue;
        }

        if (Guid.TryParse(value, out var result))
        {
            return result;
        }

        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="Guid"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsGuid(this string value, out Guid result)
    {
        return Guid.TryParse(value, out result);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="Guid"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryParseAsNullableGuid
    (
        [NotNullWhen(true)] this string? value,
        [NotNullWhen(true)] out Guid? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return false;
        }

        if (!Guid.TryParse(value, out var parsedResult))
        {
            return false;
        }

        result = parsedResult;

        return true;
    }

    /// <summary>
    /// Attempts to parse a <see cref="string"/> to a <see cref="Guid"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsGuid(this string value, out Guid result)
    {
        return !Guid.TryParse(value, out result);
    }

    /// <summary>
    /// Attempts to parse a nullable <see cref="string"/> to a <see cref="Guid"/> and returns a boolean indicating success or failure.
    /// </summary>
    public static bool TryFailParseAsNullableGuid
    (
        [NotNullWhen(false)] this string? value,
        [NotNullWhen(false)] out Guid? result
    )
    {
        result = null;

        if (value.IsNullOrEmpty())
        {
            return true;
        }

        if (!Guid.TryParse(value, out var parsedResult))
        {
            return true;
        }

        result = parsedResult;

        return false;
    }
}
