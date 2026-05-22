using AwesomeAssertions;
using System.Globalization;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StringInt16ExtensionsTests
{
    private const NumberStyles DefaultNumberStyles = NumberStyles.Integer;

    [Theory]
    [InlineData("123", (short)123)]
    [InlineData("-123", (short)-123)]
    [InlineData("0", (short)0)]
    public static void ParseAsInt16_WehnGivenOnlyAValidInt16String_ReturnsTheExpectedValue
    (
        string input,
        short expected
    )
    {
        var result = input.ParseAsInt16();

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsInt16_WhenGivenAnInvalidInt16String_ThrowsFormatException()
    {
        var input = "abc";
        var action = () => input.ParseAsInt16();

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (short)123)]
    [InlineData(" -123  ", DefaultNumberStyles, (short)-123)]
    public static void ParseAsInt16_WhenGivenAnInt16StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        short expected
    )
    {
        var result = input.ParseAsInt16(styles);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsInt16_WhenGivenAnInvalidInt16StringWithNumberStyle_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var action = () => input.ParseAsInt16(styles);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", (short)123)]
    [InlineData("-123", (short)-123)]
    [InlineData("0", (short)0)]
    public static void ParseAsInt16_WhenGivenAnInt16StringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        short expected
    )
    {
        var result = input.ParseAsInt16(CultureInfo.CurrentCulture);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsInt16_WhenGivenAnInvalidInt16StringWithFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsInt16(provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (short)123)]
    [InlineData(" -123  ", DefaultNumberStyles, (short)-123)]
    public static void ParseAsInt16_WhenGivenAnInt16StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        short expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsInt16(styles, provider);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsInt16_WhenGivenAnInvalidInt16StringWithNumberStyleAndFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsInt16(styles, provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", (short)123)]
    [InlineData("-123", (short)-123)]
    [InlineData("0", (short)0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableInt16_WhenGivenOnlyAValidInt16String_ReturnsTheExpectedValue
    (
        string? input,
        short? expected
    )
    {
        var result = input.ParseAsNullableInt16();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (short)123)]
    [InlineData(" -123  ", DefaultNumberStyles, (short)-123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableInt16_WhenGivenAnInt16StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        short? expected
    )
    {
        var result = input.ParseAsNullableInt16(styles);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", (short)123)]
    [InlineData("-123", (short)-123)]
    [InlineData("0", (short)0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableInt16_WhenGivenAnInt16WithFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        short? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableInt16(provider);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (short)123)]
    [InlineData(" -123  ", DefaultNumberStyles, (short)-123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableInt16_WhenGivenAnInt16StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        short? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableInt16(styles, provider);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", (short)123, true)]
    [InlineData("-123", (short)-123, true)]
    [InlineData("0", (short)0, true)]
    [InlineData("", (short)0, false)]
    [InlineData("invalid", (short)0, false)]
    public static void TryParseAsInt16_WhenGivenAnInt16String_ReturnsTheExpectedValue
    (
        string input,
        short expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsInt16(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (short)123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, (short)-123, true)]
    [InlineData("0", DefaultNumberStyles, (short)0, true)]
    [InlineData("", DefaultNumberStyles, (short)0, false)]
    [InlineData("invalid", DefaultNumberStyles, (short)0, false)]
    public static void TryParseAsInt16_WhenGivenAnInt16StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        short expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsInt16(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (short)123, true)]
    [InlineData("-123", (short)-123, true)]
    [InlineData("0", (short)0, true)]
    [InlineData("", (short)0, false)]
    [InlineData("invalid", (short)0, false)]
    public static void TryParseAsInt16_WhenGivenAnInt16StringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        short expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsInt16(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (short)123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, (short)-123, true)]
    [InlineData("0", DefaultNumberStyles, (short)0, true)]
    [InlineData("", DefaultNumberStyles, (short)0, false)]
    [InlineData("invalid", DefaultNumberStyles, (short)0, false)]
    public static void TryParseAsInt16_WhenGivenAnInt16StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        short expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsInt16(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (short)123, true)]
    [InlineData("-123", (short)-123, true)]
    [InlineData("0", (short)0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableInt16_WhenGivenAnInt16String_ReturnsTheExpectedValue
    (
        string? input,
        short? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableInt16(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (short)123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, (short)-123, true)]
    [InlineData("0", DefaultNumberStyles, (short)0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    [InlineData(null, DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableInt16_WhenGivenAnInt16StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        short? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableInt16(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (short)123, true)]
    [InlineData("-123", (short)-123, true)]
    [InlineData("0", (short)0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableInt16_WhenGivenAnInt16StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       short? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableInt16(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (short)123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, (short)-123, true)]
    [InlineData("0", DefaultNumberStyles, (short)0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableInt16_WhenGivenAnInt16StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       short? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableInt16(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (short)123, false)]
    [InlineData("-123", (short)-123, false)]
    [InlineData("0", (short)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsInt16_WhenGivenAnInt16String_ReturnsTheExpectedValue
    (
        string input,
        short expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsInt16(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (short)123, false)]
    [InlineData("-123", DefaultNumberStyles, (short)-123, false)]
    [InlineData("0", DefaultNumberStyles, (short)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsInt16_WhenGivenAnInt16StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        short expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsInt16(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (short)123, false)]
    [InlineData("-123", (short)-123, false)]
    [InlineData("0", (short)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsInt16_WhenGivenAnInt16StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       short expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsInt16(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (short)123, false)]
    [InlineData("-123", DefaultNumberStyles, (short)-123, false)]
    [InlineData("0", DefaultNumberStyles, (short)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsInt16_WhenGivenAnInt16StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       NumberStyles styles,
       short expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsInt16(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (short)123, false)]
    [InlineData("-123", (short)-123, false)]
    [InlineData("0", (short)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableInt16_WhenGivenAnInt16String_ReturnsTheExpectedValue
    (
        string? input,
        short? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableInt16(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (short)123, false)]
    [InlineData("-123", DefaultNumberStyles, (short)-123, false)]
    [InlineData("0", DefaultNumberStyles, (short)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableInt16_WhenGivenAnInt16StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        short? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableInt16(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (short)123, false)]
    [InlineData("-123", (short)-123, false)]
    [InlineData("0", (short)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableInt16_WhenGivenAnInt16StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       short? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableInt16(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (short)123, false)]
    [InlineData("-123", DefaultNumberStyles, (short)-123, false)]
    [InlineData("0", DefaultNumberStyles, (short)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableInt16_WhenGivenAnInt16StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       short? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableInt16(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }
}
