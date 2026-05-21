using AwesomeAssertions;
using System.Globalization;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StringFloatExtensionsTests
{
    private const NumberStyles DefaultNumberStyles = NumberStyles.Float;

    [Theory]
    [InlineData("123.123", (float)123.123)]
    [InlineData("-123.123", (float)-123.123)]
    [InlineData("0.0", (float)0.0)]
    public static void ParseAsFloat_WehnGivenOnlyAValidFloatString_ReturnsTheExpectedValue
    (
        string input,
        float expected
    )
    {
        var result = input.ParseAsFloat();

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsFloat_WhenGivenAnInvalidFloatString_ThrowsFormatException()
    {
        var input = "abc";
        var action = () => input.ParseAsFloat();

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123)]
    public static void ParseAsFloat_WhenGivenAnFloatStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        float expected
    )
    {
        var result = input.ParseAsFloat(styles);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsFloat_WhenGivenAnInvalidFloatStringWithNumberStyle_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var action = () => input.ParseAsFloat(styles);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123.123", (float)123.123)]
    [InlineData("-123.123", (float)-123.123)]
    [InlineData("0.0", (float)0.0)]
    public static void ParseAsFloat_WhenGivenAnFloatStringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        float expected
    )
    {
        var result = input.ParseAsFloat(CultureInfo.CurrentCulture);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsFloat_WhenGivenAnInvalidFloatStringWithFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsFloat(provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123)]
    public static void ParseAsFloat_WhenGivenAnFloatStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        float expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsFloat(styles, provider);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsFloat_WhenGivenAnInvalidFloatStringWithNumberStyleAndFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsFloat(styles, provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123.123", (float)123.123)]
    [InlineData("-123.123", (float)-123.123)]
    [InlineData("0.0", (float)0.0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableFloat_WhenGivenOnlyAValidFloatString_ReturnsTheExpectedValue
    (
        string? input,
        float? expected
    )
    {
        var result = input.ParseAsNullableFloat();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableFloat_WhenGivenAnFloatStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        float? expected
    )
    {
        var result = input.ParseAsNullableFloat(styles);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123.123", (float)123.123)]
    [InlineData("-123.123", (float)-123.123)]
    [InlineData("0.0", (float)0.0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableFloat_WhenGivenAnFloatWithFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        float? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableFloat(provider);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableFloat_WhenGivenAnFloatStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        float? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableFloat(styles, provider);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, true)]
    [InlineData("-123.123", (float)-123.123, true)]
    [InlineData("0.0", (float)0.0, true)]
    [InlineData("", (float)0.0, false)]
    [InlineData("invalid", (float)0.0, false)]
    public static void TryParseAsFloat_WhenGivenAnFloatString_ReturnsTheExpectedValue
    (
        string input,
        float expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsFloat(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123, true)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123, true)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, true)]
    [InlineData("", DefaultNumberStyles, (float)0.0, false)]
    [InlineData("invalid", DefaultNumberStyles, (float)0.0, false)]
    public static void TryParseAsFloat_WhenGivenAnFloatStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        float expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsFloat(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, true)]
    [InlineData("-123.123", (float)-123.123, true)]
    [InlineData("0.0", (float)0.0, true)]
    [InlineData("", (float)0.0, false)]
    [InlineData("invalid", (float)0.0, false)]
    public static void TryParseAsFloat_WhenGivenAnFloatStringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        float expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsFloat(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123, true)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123, true)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, true)]
    [InlineData("", DefaultNumberStyles, (float)0.0, false)]
    [InlineData("invalid", DefaultNumberStyles, (float)0.0, false)]
    public static void TryParseAsFloat_WhenGivenAnFloatStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        float expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsFloat(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, true)]
    [InlineData("-123.123", (float)-123.123, true)]
    [InlineData("0.0", (float)0.0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableFloat_WhenGivenAnFloatString_ReturnsTheExpectedValue
    (
        string? input,
        float? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableFloat(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123, true)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123, true)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    [InlineData(null, DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableFloat_WhenGivenAnFloatStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        float? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableFloat(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, true)]
    [InlineData("-123.123", (float)-123.123, true)]
    [InlineData("0.0", (float)0.0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableFloat_WhenGivenAnFloatStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       float? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableFloat(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123, true)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123, true)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableFloat_WhenGivenAnFloatStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       float? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableFloat(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, false)]
    [InlineData("-123.123", (float)-123.123, false)]
    [InlineData("0.0", (float)0.0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsFloat_WhenGivenAnFloatString_ReturnsTheExpectedValue
    (
        string input,
        float expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsFloat(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", DefaultNumberStyles, (float)123.123, false)]
    [InlineData("-123.123", DefaultNumberStyles, (float)-123.123, false)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsFloat_WhenGivenAnFloatStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        float expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsFloat(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, false)]
    [InlineData("-123.123", (float)-123.123, false)]
    [InlineData("0.0", (float)0.0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsFloat_WhenGivenAnFloatStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       float expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsFloat(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", DefaultNumberStyles, (float)123.123, false)]
    [InlineData("-123.123", DefaultNumberStyles, (float)-123.123, false)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsFloat_WhenGivenAnFloatStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       NumberStyles styles,
       float expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsFloat(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, false)]
    [InlineData("-123.123", (float)-123.123, false)]
    [InlineData("0.0", (float)0.0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableFloat_WhenGivenAnFloatString_ReturnsTheExpectedValue
    (
        string? input,
        float? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableFloat(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", DefaultNumberStyles, (float)123.123, false)]
    [InlineData("-123.123", DefaultNumberStyles, (float)-123.123, false)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableFloat_WhenGivenAnFloatStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        float? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableFloat(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, false)]
    [InlineData("-123.123", (float)-123.123, false)]
    [InlineData("0.0", (float)0.0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableFloat_WhenGivenAnFloatStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       float? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableFloat(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", DefaultNumberStyles, (float)123.123, false)]
    [InlineData("-123.123", DefaultNumberStyles, (float)-123.123, false)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableFloat_WhenGivenAnFloatStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       float? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableFloat(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }
}
