using FluentAssertions;
using TenjinX.Extensions;
using TenjinX.Tests.Utilities;

namespace TenjinX.Tests.ExtensionsTests;

public static class DateTimeExtensionsTests
{
    [Theory]
    [InlineData("2024-06-15T13:45:30", "2024-06-15")]
    [InlineData("2000-01-01T00:00:00", "2000-01-01")]
    public static void ToDateOnly_NonNullable_WhenGivenDateTime_ReturnsExpectedDateOnly
    (
        string dateTime,
        string expected
    )
    {
        DateTimeTestUtilities.ParseInlineStringParameters
        (
            expected,
            null,
            dateTime,
            out var parsedExpected,
            out _,
            out var parsedDateTime
        );

        var result = parsedDateTime!.Value.ToDateOnly();

        result.Should().Be(parsedExpected);
    }

    [Theory]
    [InlineData("2024-06-15T13:45:30", "2024-06-15")]
    [InlineData("2000-01-01T00:00:00", "2000-01-01")]
    [InlineData(null, null)]
    public static void ToDateOnly_Nullable_WhenGivenDateTime_ReturnsExpectedDateOnly
    (
        string? dateTime,
        string? expected
    )
    {
        DateTimeTestUtilities.ParseInlineStringParameters
        (
            expected,
            null,
            dateTime,
            out var parsedExpected,
            out _,
            out var parsedDateTime
        );

        var result = parsedDateTime.ToDateOnly();

        result.Should().Be(parsedExpected);
    }

    [Theory]
    [InlineData("2024-06-15T13:45:30", "13:45:30")]
    [InlineData("2000-01-01T00:00:00", "00:00:00")]
    public static void ToTimeOnly_NonNullable_WhenGivenDateTime_ReturnsExpectedTimeOnly
    (
        string dateTime,
        string expected
    )
    {
        DateTimeTestUtilities.ParseInlineStringParameters
        (
            null,
            expected,
            dateTime,
            out _,
            out var parsedExpected,
            out var parsedDateTime
        );

        var result = parsedDateTime!.Value.ToTimeOnly();

        result.Should().Be(parsedExpected);
    }

    [Theory]
    [InlineData("2024-06-15T13:45:30", "13:45:30")]
    [InlineData("2000-01-01T00:00:00", "00:00:00")]
    [InlineData(null, null)]
    public static void ToTimeOnly_Nullable_WhenGivenDateTime_ReturnsExpectedTimeOnly
    (
        string? dateTime,
        string? expected
    )
    {
        DateTimeTestUtilities.ParseInlineStringParameters
        (
            null,
            expected,
            dateTime,
            out _,
            out var parsedExpected,
            out var parsedDateTime
        );

        var result = parsedDateTime.ToTimeOnly();

        result.Should().Be(parsedExpected);
    }

    [Theory]
    [InlineData("2024-06-15T13:45:30", "2024-06-15", "13:45:30")]
    [InlineData("2000-01-01T00:00:00", "2000-01-01", "00:00:00")]
    public static void ToDateAndTimeOnly_NonNullable_WhenGivenDateTime_ReturnsExpectedDateOnlyAndTimeOnly
    (
        string dateTime,
        string expectedDateOnly,
        string expectedTimeOnly
    )
    {
        DateTimeTestUtilities.ParseInlineStringParameters
        (
            expectedDateOnly,
            expectedTimeOnly,
            dateTime,
            out var parsedExpectedDateOnly,
            out var parsedExpectedTimeOnly,
            out var parsedDateTime
        );

        parsedDateTime!.Value.ToDateAndTimeOnly(out var resultDateOnly, out var resultTimeOnly);

        resultDateOnly.Should().Be(parsedExpectedDateOnly);
        resultTimeOnly.Should().Be(parsedExpectedTimeOnly);
    }

    [Theory]
    [InlineData("2024-06-15T13:45:30", "2024-06-15", "13:45:30")]
    [InlineData("2000-01-01T00:00:00", "2000-01-01", "00:00:00")]
    [InlineData(null, null, null)]
    public static void ToDateAndTimeOnly_Nullable_WhenGivenDateTime_ReturnsExpectedDateOnlyAndTimeOnly
    (
        string? dateTime,
        string? expectedDateOnly,
        string? expectedTimeOnly
    )
    {
        DateTimeTestUtilities.ParseInlineStringParameters
        (
            expectedDateOnly,
            expectedTimeOnly,
            dateTime,
            out var parsedExpectedDateOnly,
            out var parsedExpectedTimeOnly,
            out var parsedDateTime
        );

        if (parsedDateTime.HasValue)
        {
            parsedDateTime.ToDateAndTimeOnly(out var resultDateOnly, out var resultTimeOnly);

            resultDateOnly.Should().Be(parsedExpectedDateOnly);
            resultTimeOnly.Should().Be(parsedExpectedTimeOnly);
        }
        else
        {
            parsedDateTime.ToDateAndTimeOnly(out var resultDateOnly, out var resultTimeOnly);

            resultDateOnly.Should().BeNull();
            resultTimeOnly.Should().BeNull();
        }
    }
}
