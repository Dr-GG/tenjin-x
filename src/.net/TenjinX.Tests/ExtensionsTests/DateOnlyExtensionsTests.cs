using FluentAssertions;
using TenjinX.Extensions;
using TenjinX.Tests.Utilities;

namespace TenjinX.Tests.ExtensionsTests;

public static class DateOnlyExtensionsTests
{
    [Theory]
    [InlineData("2024-01-01", null, "2024-01-01T00:00:00")]
    [InlineData("2024-01-01", "12:30:15", "2024-01-01T12:30:15")]
    public static void ToDateTime_NonNullable_WhenGivenValues_ReturnsTheExpectedDateTime
    (
        string dateOnly,
        string? timeOnly,
        string expected
    )
    {
        DateTimeTestUtilities.ParseInlineStringParameters
        (
            dateOnly,
            timeOnly,
            expected,
            out var parsedDateOnly,
            out var parsedTimeOnly,
            out var parsedDateTime
        );

        var result = parsedDateOnly!.Value.ToDateTime(parsedTimeOnly);

        result.Should().Be(parsedDateTime);
    }

    [Theory]
    [InlineData(null, null, null)]
    [InlineData("2024-01-01", null, "2024-01-01T00:00:00")]
    [InlineData("2024-01-01", "12:30:15", "2024-01-01T12:30:15")]
    [InlineData(null, "12:30:15", null)]
    public static void ToDateTime_Nullable_WhenGivenValues_ReturnsTheExpectedDateTime
    (
        string? dateOnly,
        string? timeOnly,
        string? expected
    )
    {
        DateTimeTestUtilities.ParseInlineStringParameters
        (
            dateOnly,
            timeOnly,
            expected,
            out var parsedDateOnly,
            out var parsedTimeOnly,
            out var parsedDateTime
        );

        var result = parsedDateOnly.ToDateTime(parsedTimeOnly);

        result.Should().Be(parsedDateTime);
    }

    [Theory]
    [InlineData("2024-01-01", null, "2024-01-01T00:00:00")]
    [InlineData("2024-01-01", "12:30:15", "2024-01-01T12:30:15")]
    public static void ToLocalDateTime_NonNullable_WhenGivenValues_ReturnsTheExpectedDateTime
    (
        string dateOnly,
        string? timeOnly,
        string expected
    )
    {
        DateTimeTestUtilities.ParseInlineStringParameters
        (
            dateOnly,
            timeOnly,
            expected,
            out var parsedDateOnly,
            out var parsedTimeOnly,
            out var parsedDateTime
        );

        var result = parsedDateOnly!.Value.ToLocalDateTime(parsedTimeOnly);

        result.Should().Be(parsedDateTime);
    }

    [Theory]
    [InlineData(null, null, null)]
    [InlineData("2024-01-01", null, "2024-01-01T00:00:00")]
    [InlineData("2024-01-01", "12:30:15", "2024-01-01T12:30:15")]
    [InlineData(null, "12:30:15", null)]
    public static void ToLocalDateTime_Nullable_WhenGivenValues_ReturnsTheExpectedDateTime
    (
        string? dateOnly,
        string? timeOnly,
        string? expected
    )
    {
        DateTimeTestUtilities.ParseInlineStringParameters
        (
            dateOnly,
            timeOnly,
            expected,
            out var parsedDateOnly,
            out var parsedTimeOnly,
            out var parsedDateTime
        );

        var result = parsedDateOnly.ToLocalDateTime(parsedTimeOnly);

        result.Should().Be(parsedDateTime);
    }

    [Theory]
    [InlineData("2024-01-01", null, "2024-01-01T00:00:00")]
    [InlineData("2024-01-01", "12:30:15", "2024-01-01T12:30:15")]
    public static void ToUtcDateTime_NonNullable_WhenGivenValues_ReturnsTheExpectedDateTime
    (
        string dateOnly,
        string? timeOnly,
        string expected
    )
    {
        DateTimeTestUtilities.ParseInlineStringParameters
        (
            dateOnly,
            timeOnly,
            expected,
            out var parsedDateOnly,
            out var parsedTimeOnly,
            out var parsedDateTime
        );

        var result = parsedDateOnly!.Value.ToUtcDateTime(parsedTimeOnly);

        result.Should().Be(parsedDateTime);
    }

    [Theory]
    [InlineData(null, null, null)]
    [InlineData("2024-01-01", null, "2024-01-01T00:00:00")]
    [InlineData("2024-01-01", "12:30:15", "2024-01-01T12:30:15")]
    [InlineData(null, "12:30:15", null)]
    public static void ToUtcDateTime_Nullable_WhenGivenValues_ReturnsTheExpectedDateTime
(
    string? dateOnly,
    string? timeOnly,
    string? expected
)
    {
        DateTimeTestUtilities.ParseInlineStringParameters
        (
            dateOnly,
            timeOnly,
            expected,
            out var parsedDateOnly,
            out var parsedTimeOnly,
            out var parsedDateTime
        );

        var result = parsedDateOnly.ToUtcDateTime(parsedTimeOnly);

        result.Should().Be(parsedDateTime);
    }
}
