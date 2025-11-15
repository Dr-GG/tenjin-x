using System;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of extension methods for the <see cref="DateOnly"/> class.
/// </summary>
public static class DateOnlyExtensions
{
    /// <summary>
    /// Converts a <see cref="DateOnly"/> to a <see cref="DateTime"/> using an <see cref="DateTimeKind.Unspecified"/> type.
    /// </summary>
    public static DateTime ToDateTime(this DateOnly dateOnly, TimeOnly? timeOnly = null)
    {
        return dateOnly.ToDateTime(timeOnly ?? TimeOnly.MinValue, DateTimeKind.Unspecified);
    }

    /// <summary>
    /// Converts a nullable <see cref="DateOnly"/> to a nullable <see cref="DateTime"/> using an <see cref="DateTimeKind.Unspecified"/> type.
    /// </summary>
    public static DateTime? ToDateTime(this DateOnly? dateOnly, TimeOnly? timeOnly = null)
    {
        return dateOnly.HasValue
            ? dateOnly.Value.ToDateTime(timeOnly ?? TimeOnly.MinValue, DateTimeKind.Unspecified)
            : null;
    }

    /// <summary>
    /// Converts a <see cref="DateOnly"/> to a <see cref="DateTime"/> using an <see cref="DateTimeKind.Local"/> type.
    /// </summary>
    public static DateTime ToLocalDateTime(this DateOnly dateOnly, TimeOnly? timeOnly = null)
    {
        return dateOnly.ToDateTime(timeOnly ?? TimeOnly.MinValue, DateTimeKind.Local);
    }

    /// <summary>
    /// Converts a nullable <see cref="DateOnly"/> to a nullable <see cref="DateTime"/> using an <see cref="DateTimeKind.Local"/> type.
    /// </summary>
    public static DateTime? ToLocalDateTime(this DateOnly? dateOnly, TimeOnly? timeOnly = null)
    {
        return dateOnly.HasValue
            ? dateOnly.Value.ToDateTime(timeOnly ?? TimeOnly.MinValue, DateTimeKind.Local)
            : null;
    }

    /// <summary>
    /// Converts a <see cref="DateOnly"/> to a <see cref="DateTime"/> using an <see cref="DateTimeKind.Utc"/> type.
    /// </summary>
    public static DateTime ToUtcDateTime(this DateOnly dateOnly, TimeOnly? timeOnly = null)
    {
        return dateOnly.ToDateTime(timeOnly ?? TimeOnly.MinValue, DateTimeKind.Utc);
    }

    /// <summary>
    /// Converts a nullable <see cref="DateOnly"/> to a nullable <see cref="DateTime"/> using an <see cref="DateTimeKind.Utc"/> type.
    /// </summary>
    public static DateTime? ToUtcDateTime(this DateOnly? dateOnly, TimeOnly? timeOnly = null)
    {
        return dateOnly.HasValue
            ? dateOnly.Value.ToDateTime(timeOnly ?? TimeOnly.MinValue, DateTimeKind.Utc)
            : null;
    }
}
