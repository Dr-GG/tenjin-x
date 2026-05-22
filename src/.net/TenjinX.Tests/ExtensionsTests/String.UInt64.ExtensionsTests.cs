using AwesomeAssertions;
using System.Globalization;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StringUInt64ExtensionsTests
{
    private const NumberStyles DefaultNumberStyles = NumberStyles.Integer;

    [Theory]
    [InlineData("123", (ulong)123)]
    [InlineData("0", (ulong)0)]
    public static void ParseAsUInt64_WehnGivenOnlyAValidUInt64String_ReturnsTheExpectedValue
    (
        string input,
        ulong expected
    )
    {
        var result = input.ParseAsUInt64();

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsUInt64_WhenGivenAnInvalidUInt64String_ThrowsFormatException()
    {
        var input = "abc";
        var action = () => input.ParseAsUInt64();

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ulong)123)]
    public static void ParseAsUInt64_WhenGivenAnUInt64StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        ulong expected
    )
    {
        var result = input.ParseAsUInt64(styles);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsUInt64_WhenGivenAnInvalidUInt64StringWithNumberStyle_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var action = () => input.ParseAsUInt64(styles);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", (ulong)123)]
    [InlineData("0", (ulong)0)]
    public static void ParseAsUInt64_WhenGivenAnUInt64StringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        ulong expected
    )
    {
        var result = input.ParseAsUInt64(CultureInfo.CurrentCulture);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsUInt64_WhenGivenAnInvalidUInt64StringWithFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsUInt64(provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ulong)123)]
    public static void ParseAsUInt64_WhenGivenAnUInt64StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        ulong expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsUInt64(styles, provider);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsUInt64_WhenGivenAnInvalidUInt64StringWithNumberStyleAndFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsUInt64(styles, provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", (ulong)123)]
    [InlineData("0", (ulong)0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableUInt64_WhenGivenOnlyAValidUInt64String_ReturnsTheExpectedValue
    (
        string? input,
        ulong? expected
    )
    {
        var result = input.ParseAsNullableUInt64();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ulong)123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableUInt64_WhenGivenAnUInt64StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        ulong? expected
    )
    {
        var result = input.ParseAsNullableUInt64(styles);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", (ulong)123)]
    [InlineData("0", (ulong)0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableUInt64_WhenGivenAnUInt64WithFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        ulong? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableUInt64(provider);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ulong)123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableUInt64_WhenGivenAnUInt64StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        ulong? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableUInt64(styles, provider);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", (ulong)123, true)]
    [InlineData("0", (ulong)0, true)]
    [InlineData("", (ulong)0, false)]
    [InlineData("invalid", (ulong)0, false)]
    public static void TryParseAsUInt64_WhenGivenAnUInt64String_ReturnsTheExpectedValue
    (
        string input,
        ulong expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsUInt64(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ulong)123, true)]
    [InlineData("0", DefaultNumberStyles, (ulong)0, true)]
    [InlineData("", DefaultNumberStyles, (ulong)0, false)]
    [InlineData("invalid", DefaultNumberStyles, (ulong)0, false)]
    public static void TryParseAsUInt64_WhenGivenAnUInt64StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        ulong expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsUInt64(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (ulong)123, true)]
    [InlineData("0", (ulong)0, true)]
    [InlineData("", (ulong)0, false)]
    [InlineData("invalid", (ulong)0, false)]
    public static void TryParseAsUInt64_WhenGivenAnUInt64StringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        ulong expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsUInt64(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ulong)123, true)]
    [InlineData("0", DefaultNumberStyles, (ulong)0, true)]
    [InlineData("", DefaultNumberStyles, (ulong)0, false)]
    [InlineData("invalid", DefaultNumberStyles, (ulong)0, false)]
    public static void TryParseAsUInt64_WhenGivenAnUInt64StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        ulong expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsUInt64(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (ulong)123, true)]
    [InlineData("0", (ulong)0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableUInt64_WhenGivenAnUInt64String_ReturnsTheExpectedValue
    (
        string? input,
        ulong? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableUInt64(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ulong)123, true)]
    [InlineData("0", DefaultNumberStyles, (ulong)0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    [InlineData(null, DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableUInt64_WhenGivenAnUInt64StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        ulong? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableUInt64(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (ulong)123, true)]
    [InlineData("0", (ulong)0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableUInt64_WhenGivenAnUInt64StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       ulong? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableUInt64(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ulong)123, true)]
    [InlineData("0", DefaultNumberStyles, (ulong)0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableUInt64_WhenGivenAnUInt64StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       ulong? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableUInt64(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (ulong)123, false)]
    [InlineData("0", (ulong)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsUInt64_WhenGivenAnUInt64String_ReturnsTheExpectedValue
    (
        string input,
        ulong expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsUInt64(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (ulong)123, false)]
    [InlineData("0", DefaultNumberStyles, (ulong)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsUInt64_WhenGivenAnUInt64StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        ulong expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsUInt64(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (ulong)123, false)]
    [InlineData("0", (ulong)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsUInt64_WhenGivenAnUInt64StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       ulong expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsUInt64(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (ulong)123, false)]
    [InlineData("0", DefaultNumberStyles, (ulong)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsUInt64_WhenGivenAnUInt64StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       NumberStyles styles,
       ulong expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsUInt64(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (ulong)123, false)]
    [InlineData("0", (ulong)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableUInt64_WhenGivenAnUInt64String_ReturnsTheExpectedValue
    (
        string? input,
        ulong? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableUInt64(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (ulong)123, false)]
    [InlineData("0", DefaultNumberStyles, (ulong)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableUInt64_WhenGivenAnUInt64StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        ulong? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableUInt64(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (ulong)123, false)]
    [InlineData("0", (ulong)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableUInt64_WhenGivenAnUInt64StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       ulong? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableUInt64(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (ulong)123, false)]
    [InlineData("0", DefaultNumberStyles, (ulong)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableUInt64_WhenGivenAnUInt64StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       ulong? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableUInt64(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }
}
