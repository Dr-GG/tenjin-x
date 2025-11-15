using TenjinX.Extensions;

namespace TenjinX.Tests.Utilities;

public static class DateTimeTestUtilities
{
    public static void ParseInlineStringParameters
    (
        string? dateOnly,
        string? timeOnly,
        string? dateTime,
        out DateOnly? parsedDateOnly,
        out TimeOnly? parsedTimeOnly,
        out DateTime? parsedDateTime
    )
    {
        parsedDateOnly = dateOnly.IsNullOrEmpty()
            ? null
            : DateOnly.ParseExact(dateOnly!, "yyyy-MM-dd");

        parsedTimeOnly = timeOnly.IsNullOrEmpty()
            ? null
            : TimeOnly.ParseExact(timeOnly!, "HH:mm:ss");

        parsedDateTime = dateTime.IsNullOrEmpty()
            ? null
            : DateTime.ParseExact(dateTime!, "yyyy-MM-ddTHH:mm:ss", null);
    }
}
