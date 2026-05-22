using AwesomeAssertions;
using System.Globalization;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StringDecimalExtensionsTests
{
    /*
     * Decimals are not seen as compile-time constants in C#.
     * Thus, use float literals in the test data and cast them to decimal in the assertions to avoid issues with precision and readability.
     */

    private const NumberStyles DefaultNumberStyles = NumberStyles.Number;

    [Theory]
    [InlineData("123.123", (float)123.123)]
    [InlineData("-123.123", (float)-123.123)]
    [InlineData("0.0", (float)0.0)]
    public static void ParseAsDecimal_WehnGivenOnlyAValidDecimalString_ReturnsTheExpectedValue
    (
        string input,
        float expected
    )
    {
        var result = input.ParseAsDecimal();

        result.Should().Be((decimal)expected);
    }

    [Fact]
    public static void ParseAsDecimal_WhenGivenAnInvalidDecimalString_ThrowsFormatException()
    {
        var input = "abc";
        var action = () => input.ParseAsDecimal();

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123)]
    public static void ParseAsDecimal_WhenGivenAnDecimalStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        float expected
    )
    {
        var result = input.ParseAsDecimal(styles);

        result.Should().Be((decimal)expected);
    }

    [Fact]
    public static void ParseAsDecimal_WhenGivenAnInvalidDecimalStringWithNumberStyle_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var action = () => input.ParseAsDecimal(styles);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123.123", (float)123.123)]
    [InlineData("-123.123", (float)-123.123)]
    [InlineData("0.0", (float)0.0)]
    public static void ParseAsDecimal_WhenGivenAnDecimalStringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        float expected
    )
    {
        var result = input.ParseAsDecimal(CultureInfo.CurrentCulture);

        result.Should().Be((decimal)expected);
    }

    [Fact]
    public static void ParseAsDecimal_WhenGivenAnInvalidDecimalStringWithFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsDecimal(provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123)]
    public static void ParseAsDecimal_WhenGivenAnDecimalStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        float expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsDecimal(styles, provider);

        result.Should().Be((decimal)expected);
    }

    [Fact]
    public static void ParseAsDecimal_WhenGivenAnInvalidDecimalStringWithNumberStyleAndFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsDecimal(styles, provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123.123", (float)123.123)]
    [InlineData("-123.123", (float)-123.123)]
    [InlineData("0.0", (float)0.0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableDecimal_WhenGivenOnlyAValidDecimalString_ReturnsTheExpectedValue
    (
        string? input,
        float? expected
    )
    {
        var result = input.ParseAsNullableDecimal();

        result.Should().Be((decimal?)expected);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableDecimal_WhenGivenAnDecimalStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        float? expected
    )
    {
        var result = input.ParseAsNullableDecimal(styles);

        result.Should().Be((decimal?)expected);
    }

    [Theory]
    [InlineData("123.123", (float)123.123)]
    [InlineData("-123.123", (float)-123.123)]
    [InlineData("0.0", (float)0.0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableDecimal_WhenGivenAnDecimalWithFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        float? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableDecimal(provider);

        result.Should().Be((decimal?)expected);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableDecimal_WhenGivenAnDecimalStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        float? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableDecimal(styles, provider);

        result.Should().Be((decimal?)expected);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, true)]
    [InlineData("-123.123", (float)-123.123, true)]
    [InlineData("0.0", (float)0.0, true)]
    [InlineData("", (float)0.0, false)]
    [InlineData("invalid", (float)0.0, false)]
    public static void TryParseAsDecimal_WhenGivenAnDecimalString_ReturnsTheExpectedValue
    (
        string input,
        float expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsDecimal(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal)expectedNumber);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123, true)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123, true)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, true)]
    [InlineData("", DefaultNumberStyles, (float)0.0, false)]
    [InlineData("invalid", DefaultNumberStyles, (float)0.0, false)]
    public static void TryParseAsDecimal_WhenGivenAnDecimalStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        float expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsDecimal(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal)expectedNumber);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, true)]
    [InlineData("-123.123", (float)-123.123, true)]
    [InlineData("0.0", (float)0.0, true)]
    [InlineData("", (float)0.0, false)]
    [InlineData("invalid", (float)0.0, false)]
    public static void TryParseAsDecimal_WhenGivenAnDecimalStringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        float expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsDecimal(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal)expectedNumber);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123, true)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123, true)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, true)]
    [InlineData("", DefaultNumberStyles, (float)0.0, false)]
    [InlineData("invalid", DefaultNumberStyles, (float)0.0, false)]
    public static void TryParseAsDecimal_WhenGivenAnDecimalStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        float expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsDecimal(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal)expectedNumber);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, true)]
    [InlineData("-123.123", (float)-123.123, true)]
    [InlineData("0.0", (float)0.0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableDecimal_WhenGivenAnDecimalString_ReturnsTheExpectedValue
    (
        string? input,
        float? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableDecimal(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal?)expectedNumber);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123, true)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123, true)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    [InlineData(null, DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableDecimal_WhenGivenAnDecimalStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        float? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableDecimal(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal?)expectedNumber);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, true)]
    [InlineData("-123.123", (float)-123.123, true)]
    [InlineData("0.0", (float)0.0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableDecimal_WhenGivenAnDecimalStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       float? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableDecimal(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal?)expectedNumber);
    }

    [Theory]
    [InlineData("  123.123  ", DefaultNumberStyles, (float)123.123, true)]
    [InlineData(" -123.123  ", DefaultNumberStyles, (float)-123.123, true)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableDecimal_WhenGivenAnDecimalStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       float? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableDecimal(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal?)expectedNumber);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, false)]
    [InlineData("-123.123", (float)-123.123, false)]
    [InlineData("0.0", (float)0.0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsDecimal_WhenGivenAnDecimalString_ReturnsTheExpectedValue
    (
        string input,
        float expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsDecimal(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal?)expectedNumber);
    }

    [Theory]
    [InlineData("123.123", DefaultNumberStyles, (float)123.123, false)]
    [InlineData("-123.123", DefaultNumberStyles, (float)-123.123, false)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsDecimal_WhenGivenAnDecimalStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        float expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsDecimal(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal?)expectedNumber);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, false)]
    [InlineData("-123.123", (float)-123.123, false)]
    [InlineData("0.0", (float)0.0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsDecimal_WhenGivenAnDecimalStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       float expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsDecimal(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal)expectedNumber);
    }

    [Theory]
    [InlineData("123.123", DefaultNumberStyles, (float)123.123, false)]
    [InlineData("-123.123", DefaultNumberStyles, (float)-123.123, false)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsDecimal_WhenGivenAnDecimalStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       NumberStyles styles,
       float expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsDecimal(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal)expectedNumber);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, false)]
    [InlineData("-123.123", (float)-123.123, false)]
    [InlineData("0.0", (float)0.0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableDecimal_WhenGivenAnDecimalString_ReturnsTheExpectedValue
    (
        string? input,
        float? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableDecimal(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal?)expectedNumber);
    }

    [Theory]
    [InlineData("123.123", DefaultNumberStyles, (float)123.123, false)]
    [InlineData("-123.123", DefaultNumberStyles, (float)-123.123, false)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableDecimal_WhenGivenAnDecimalStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        float? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableDecimal(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal?)expectedNumber);
    }

    [Theory]
    [InlineData("123.123", (float)123.123, false)]
    [InlineData("-123.123", (float)-123.123, false)]
    [InlineData("0.0", (float)0.0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableDecimal_WhenGivenAnDecimalStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       float? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableDecimal(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal?)expectedNumber);
    }

    [Theory]
    [InlineData("123.123", DefaultNumberStyles, (float)123.123, false)]
    [InlineData("-123.123", DefaultNumberStyles, (float)-123.123, false)]
    [InlineData("0.0", DefaultNumberStyles, (float)0.0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableDecimal_WhenGivenAnDecimalStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       float? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableDecimal(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be((decimal?)expectedNumber);
    }
}
