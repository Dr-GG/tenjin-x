using AwesomeAssertions;
using System.Globalization;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StringDoubleExtensionsTests
{
    private const NumberStyles DefaultNumberStyles = NumberStyles.Float;

    [Theory]
    [InlineData("123.123", 123.123)]
    [InlineData("-123.123", -123.123)]
    [InlineData("0.0", 0.0)]
    public static void ParseAsDouble_WehnGivenOnlyAValidDoubleString_ReturnsTheExpectedValue
    (
        string input,
        double expected
    )
    {
        var result = input.ParseAsDouble();

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsDouble_WhenGivenAnInvalidDoubleString_ThrowsFormatException()
    {
        var input = "abc";
        var action = () => input.ParseAsDouble();

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, 123.123)]
    [InlineData(" -123.123  ", DefaultNumberStyles, -123.123)]
    public static void ParseAsDouble_WhenGivenAnDoubleStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        double expected
    )
    {
        var result = input.ParseAsDouble(styles);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsDouble_WhenGivenAnInvalidDoubleStringWithNumberStyle_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var action = () => input.ParseAsDouble(styles);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123.123", 123.123)]
    [InlineData("-123.123", -123.123)]
    [InlineData("0.0", 0.0)]
    public static void ParseAsDouble_WhenGivenAnDoubleStringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        double expected
    )
    {
        var result = input.ParseAsDouble(CultureInfo.CurrentCulture);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsDouble_WhenGivenAnInvalidDoubleStringWithFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsDouble(provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, 123.123)]
    [InlineData(" -123.123  ", DefaultNumberStyles, -123.123)]
    public static void ParseAsDouble_WhenGivenAnDoubleStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        double expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsDouble(styles, provider);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsDouble_WhenGivenAnInvalidDoubleStringWithNumberStyleAndFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsDouble(styles, provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123.123", 123.123)]
    [InlineData("-123.123", -123.123)]
    [InlineData("0.0", 0.0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableDouble_WhenGivenOnlyAValidDoubleString_ReturnsTheExpectedValue
    (
        string? input,
        double? expected
    )
    {
        var result = input.ParseAsNullableDouble();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, 123.123)]
    [InlineData(" -123.123  ", DefaultNumberStyles, -123.123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableDouble_WhenGivenAnDoubleStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        double? expected
    )
    {
        var result = input.ParseAsNullableDouble(styles);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123.123", 123.123)]
    [InlineData("-123.123", -123.123)]
    [InlineData("0.0", 0.0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableDouble_WhenGivenAnDoubleWithFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        double? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableDouble(provider);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, 123.123)]
    [InlineData(" -123.123  ", DefaultNumberStyles, -123.123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableDouble_WhenGivenAnDoubleStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        double? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableDouble(styles, provider);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123.123", 123.123, true)]
    [InlineData("-123.123", -123.123, true)]
    [InlineData("0.0", 0.0, true)]
    [InlineData("", 0.0, false)]
    [InlineData("invalid", 0.0, false)]
    public static void TryParseAsDouble_WhenGivenAnDoubleString_ReturnsTheExpectedValue
    (
        string input,
        double expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsDouble(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, 123.123, true)]
    [InlineData(" -123.123  ", DefaultNumberStyles, -123.123, true)]
    [InlineData("0.0", DefaultNumberStyles, 0.0, true)]
    [InlineData("", DefaultNumberStyles, 0.0, false)]
    [InlineData("invalid", DefaultNumberStyles, 0.0, false)]
    public static void TryParseAsDouble_WhenGivenAnDoubleStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        double expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsDouble(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", 123.123, true)]
    [InlineData("-123.123", -123.123, true)]
    [InlineData("0.0", 0.0, true)]
    [InlineData("", 0.0, false)]
    [InlineData("invalid", 0.0, false)]
    public static void TryParseAsDouble_WhenGivenAnDoubleStringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        double expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsDouble(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, 123.123, true)]
    [InlineData(" -123.123  ", DefaultNumberStyles, -123.123, true)]
    [InlineData("0.0", DefaultNumberStyles, 0.0, true)]
    [InlineData("", DefaultNumberStyles, 0.0, false)]
    [InlineData("invalid", DefaultNumberStyles, 0.0, false)]
    public static void TryParseAsDouble_WhenGivenAnDoubleStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        double expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsDouble(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", 123.123, true)]
    [InlineData("-123.123", -123.123, true)]
    [InlineData("0.0", 0.0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableDouble_WhenGivenAnDoubleString_ReturnsTheExpectedValue
    (
        string? input,
        double? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableDouble(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, 123.123, true)]
    [InlineData(" -123.123  ", DefaultNumberStyles, -123.123, true)]
    [InlineData("0.0", DefaultNumberStyles, 0.0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    [InlineData(null, DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableDouble_WhenGivenAnDoubleStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        double? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableDouble(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", 123.123, true)]
    [InlineData("-123.123", -123.123, true)]
    [InlineData("0.0", 0.0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableDouble_WhenGivenAnDoubleStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       double? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableDouble(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, 123.123, true)]
    [InlineData(" -123.123  ", DefaultNumberStyles, -123.123, true)]
    [InlineData("0.0", DefaultNumberStyles, 0.0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableDouble_WhenGivenAnDoubleStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       double? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableDouble(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", 123.123, false)]
    [InlineData("-123.123", -123.123, false)]
    [InlineData("0.0", 0.0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsDouble_WhenGivenAnDoubleString_ReturnsTheExpectedValue
    (
        string input,
        double expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsDouble(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", DefaultNumberStyles, 123.123, false)]
    [InlineData("-123.123", DefaultNumberStyles, -123.123, false)]
    [InlineData("0.0", DefaultNumberStyles, 0.0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsDouble_WhenGivenAnDoubleStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        double expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsDouble(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", 123.123, false)]
    [InlineData("-123.123", -123.123, false)]
    [InlineData("0.0", 0.0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsDouble_WhenGivenAnDoubleStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       double expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsDouble(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", DefaultNumberStyles, 123.123, false)]
    [InlineData("-123.123", DefaultNumberStyles, -123.123, false)]
    [InlineData("0.0", DefaultNumberStyles, 0.0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsDouble_WhenGivenAnDoubleStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       NumberStyles styles,
       double expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsDouble(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", 123.123, false)]
    [InlineData("-123.123", -123.123, false)]
    [InlineData("0.0", 0.0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableDouble_WhenGivenAnDoubleString_ReturnsTheExpectedValue
    (
        string? input,
        double? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableDouble(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", DefaultNumberStyles, 123.123, false)]
    [InlineData("-123.123", DefaultNumberStyles, -123.123, false)]
    [InlineData("0.0", DefaultNumberStyles, 0.0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableDouble_WhenGivenAnDoubleStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        double? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableDouble(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", 123.123, false)]
    [InlineData("-123.123", -123.123, false)]
    [InlineData("0.0", 0.0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableDouble_WhenGivenAnDoubleStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       double? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableDouble(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123.123", DefaultNumberStyles, 123.123, false)]
    [InlineData("-123.123", DefaultNumberStyles, -123.123, false)]
    [InlineData("0.0", DefaultNumberStyles, 0.0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableDouble_WhenGivenAnDoubleStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       double? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableDouble(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }
}
