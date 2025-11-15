using System;
using System.Diagnostics.CodeAnalysis;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of extension methods for the <see cref="string"/> class.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Determines if a <see cref="string"/> instance is null or empty.
    /// </summary>
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
    {
        return string.IsNullOrEmpty(value);
    }

    /// <summary>
    /// Determines if a <see cref="string"/> instance is not null and not empty.
    /// </summary>
    public static bool IsNotNullAndEmpty([NotNullWhen(true)] this string? value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    /// Determines if a <see cref="string"/> instance is null or consists only of white-space characters.
    /// </summary>
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    /// Determines if a <see cref="string"/> instance is not null and does not consist only of white-space characters.
    /// </summary>
    public static bool IsNotNullAndWhiteSpace([NotNullWhen(true)] this string? value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    /// Determines if a <see cref="string"/> instance is empty.
    /// </summary>
    public static bool IsEmpty(this string value)
    {
        return value.Length == 0;
    }

    /// <summary>
    /// Determines if a <see cref="string"/> instance is not empty.
    /// </summary>
    public static bool IsNotEmpty(this string value)
    {
        return value.Length > 0;
    }

    /// <summary>
    /// Determines if a <see cref="string"/> instance consists only of white-space characters.
    /// </summary>
    public static bool IsEmptyOrWhiteSpace(this string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    /// Determines if a <see cref="string"/> instance does not consist only of white-space characters.
    /// </summary>
    public static bool IsNotEmptyOrWhiteSpace(this string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    /// Determines if two String instances equals one another with StringComparison.OrdinalIgnoreCase.
    /// </summary>
    public static bool EqualsOrdinalIgnoreCase(this string? value, string? compare)
    {
        return string.Equals(value, compare, StringComparison.OrdinalIgnoreCase);
    }
}