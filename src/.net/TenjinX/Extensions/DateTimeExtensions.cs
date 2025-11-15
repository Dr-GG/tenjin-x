using System;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of extension methods for the <see cref="DateTime"/> class.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Converts a <see cref="DateTime"/> to a <see cref="DateOnly"/>.
    /// </summary>
    public static DateOnly ToDateOnly(this DateTime dateTime)
    {
        return DateOnly.FromDateTime(dateTime);
    }

    /// <summary>
    /// Converts a nullable <see cref="DateTime"/> to a nullable <see cref="DateOnly"/>.
    /// </summary>
    public static DateOnly? ToDateOnly(this DateTime? dateTime)
    {
        return dateTime.HasValue
            ? DateOnly.FromDateTime(dateTime.Value)
            : null;
    }

    /// <summary>
    /// Converts a <see cref="DateTime"/> to a <see cref="TimeOnly"/>.
    /// </summary>
    public static TimeOnly ToTimeOnly(this DateTime dateTime)
    {
        return TimeOnly.FromDateTime(dateTime);
    }

    /// <summary>
    /// Converts a nullable <see cref="DateTime"/> to a nullable <see cref="TimeOnly"/>.
    /// </summary>
    public static TimeOnly? ToTimeOnly(this DateTime? dateTime)
    {
        return dateTime.HasValue
            ? TimeOnly.FromDateTime(dateTime.Value)
            : null;
    }

    /// <summary>
    /// Deconstructs a <see cref="DateTime"/> into its <see cref="DateOnly"/> and <see cref="TimeOnly"/> components.
    /// </summary>
    public static void ToDateAndTimeOnly(this DateTime dateTime, out DateOnly dateOnly, out TimeOnly timeOnly)
    {
        dateOnly = DateOnly.FromDateTime(dateTime);
        timeOnly = TimeOnly.FromDateTime(dateTime);
    }

    /// <summary>
    /// Deconstructs a nullable <see cref="DateTime"/> into its nullable <see cref="DateOnly"/> and <see cref="TimeOnly"/> components.
    /// </summary>
    public static void ToDateAndTimeOnly(this DateTime? dateTime, out DateOnly? dateOnly, out TimeOnly? timeOnly)
    {
        if (dateTime.HasValue)
        {
            dateOnly = DateOnly.FromDateTime(dateTime.Value);
            timeOnly = TimeOnly.FromDateTime(dateTime.Value);
        }
        else
        {
            dateOnly = null;
            timeOnly = null;
        }
    }
}
