using AwesomeAssertions;
using System.Globalization;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StringSByteExtensionsTests
{
    private const NumberStyles DefaultNumberStyles = NumberStyles.Integer;

    [Theory]
    [InlineData("123", (sbyte)123)]
    [InlineData("-123", (sbyte)-123)]
    [InlineData("0", (sbyte)0)]
    public static void ParseAsSByte_WehnGivenOnlyAValidSByteString_ReturnsTheExpectedValue
    (
        string input,
        sbyte expected
    )
    {
        var result = input.ParseAsSByte();

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsSByte_WhenGivenAnInvalidSByteString_ThrowsFormatException()
    {
        var input = "abc";
        var action = () => input.ParseAsSByte();

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (sbyte)123)]
    [InlineData(" -123  ", DefaultNumberStyles, (sbyte)-123)]
    public static void ParseAsSByte_WhenGivenAnSByteStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        sbyte expected
    )
    {
        var result = input.ParseAsSByte(styles);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsSByte_WhenGivenAnInvalidSByteStringWithNumberStyle_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var action = () => input.ParseAsSByte(styles);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", (sbyte)123)]
    [InlineData("-123", (sbyte)-123)]
    [InlineData("0", (sbyte)0)]
    public static void ParseAsSByte_WhenGivenAnSByteStringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        sbyte expected
    )
    {
        var result = input.ParseAsSByte(CultureInfo.CurrentCulture);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsSByte_WhenGivenAnInvalidSByteStringWithFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsSByte(provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (sbyte)123)]
    [InlineData(" -123  ", DefaultNumberStyles, (sbyte)-123)]
    public static void ParseAsSByte_WhenGivenAnSByteStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        sbyte expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsSByte(styles, provider);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsSByte_WhenGivenAnInvalidSByteStringWithNumberStyleAndFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsSByte(styles, provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", (sbyte)123)]
    [InlineData("-123", (sbyte)-123)]
    [InlineData("0", (sbyte)0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableSByte_WhenGivenOnlyAValidSByteString_ReturnsTheExpectedValue
    (
        string? input,
        sbyte? expected
    )
    {
        var result = input.ParseAsNullableSByte();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (sbyte)123)]
    [InlineData(" -123  ", DefaultNumberStyles, (sbyte)-123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableSByte_WhenGivenAnSByteStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        sbyte? expected
    )
    {
        var result = input.ParseAsNullableSByte(styles);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", (sbyte)123)]
    [InlineData("-123", (sbyte)-123)]
    [InlineData("0", (sbyte)0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableSByte_WhenGivenAnSByteWithFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        sbyte? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableSByte(provider);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (sbyte)123)]
    [InlineData(" -123  ", DefaultNumberStyles, (sbyte)-123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableSByte_WhenGivenAnSByteStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        sbyte? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableSByte(styles, provider);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", (sbyte)123, true)]
    [InlineData("-123", (sbyte)-123, true)]
    [InlineData("0", (sbyte)0, true)]
    [InlineData("", (sbyte)0, false)]
    [InlineData("invalid", (sbyte)0, false)]
    public static void TryParseAsSByte_WhenGivenAnSByteString_ReturnsTheExpectedValue
    (
        string input,
        sbyte expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsSByte(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (sbyte)123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, (sbyte)-123, true)]
    [InlineData("0", DefaultNumberStyles, (sbyte)0, true)]
    [InlineData("", DefaultNumberStyles, (sbyte)0, false)]
    [InlineData("invalid", DefaultNumberStyles, (sbyte)0, false)]
    public static void TryParseAsSByte_WhenGivenAnSByteStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        sbyte expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsSByte(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (sbyte)123, true)]
    [InlineData("-123", (sbyte)-123, true)]
    [InlineData("0", (sbyte)0, true)]
    [InlineData("", (sbyte)0, false)]
    [InlineData("invalid", (sbyte)0, false)]
    public static void TryParseAsSByte_WhenGivenAnSByteStringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        sbyte expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsSByte(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (sbyte)123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, (sbyte)-123, true)]
    [InlineData("0", DefaultNumberStyles, (sbyte)0, true)]
    [InlineData("", DefaultNumberStyles, (sbyte)0, false)]
    [InlineData("invalid", DefaultNumberStyles, (sbyte)0, false)]
    public static void TryParseAsSByte_WhenGivenAnSByteStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        sbyte expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsSByte(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (sbyte)123, true)]
    [InlineData("-123", (sbyte)-123, true)]
    [InlineData("0", (sbyte)0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableSByte_WhenGivenAnSByteString_ReturnsTheExpectedValue
    (
        string? input,
        sbyte? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableSByte(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (sbyte)123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, (sbyte)-123, true)]
    [InlineData("0", DefaultNumberStyles, (sbyte)0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    [InlineData(null, DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableSByte_WhenGivenAnSByteStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        sbyte? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableSByte(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (sbyte)123, true)]
    [InlineData("-123", (sbyte)-123, true)]
    [InlineData("0", (sbyte)0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableSByte_WhenGivenAnSByteStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       sbyte? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableSByte(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (sbyte)123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, (sbyte)-123, true)]
    [InlineData("0", DefaultNumberStyles, (sbyte)0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableSByte_WhenGivenAnSByteStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       sbyte? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableSByte(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (sbyte)123, false)]
    [InlineData("-123", (sbyte)-123, false)]
    [InlineData("0", (sbyte)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsSByte_WhenGivenAnSByteString_ReturnsTheExpectedValue
    (
        string input,
        sbyte expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsSByte(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (sbyte)123, false)]
    [InlineData("-123", DefaultNumberStyles, (sbyte)-123, false)]
    [InlineData("0", DefaultNumberStyles, (sbyte)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsSByte_WhenGivenAnSByteStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        sbyte expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsSByte(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (sbyte)123, false)]
    [InlineData("-123", (sbyte)-123, false)]
    [InlineData("0", (sbyte)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsSByte_WhenGivenAnSByteStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       sbyte expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsSByte(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (sbyte)123, false)]
    [InlineData("-123", DefaultNumberStyles, (sbyte)-123, false)]
    [InlineData("0", DefaultNumberStyles, (sbyte)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsSByte_WhenGivenAnSByteStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       NumberStyles styles,
       sbyte expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsSByte(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (sbyte)123, false)]
    [InlineData("-123", (sbyte)-123, false)]
    [InlineData("0", (sbyte)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableSByte_WhenGivenAnSByteString_ReturnsTheExpectedValue
    (
        string? input,
        sbyte? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableSByte(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (sbyte)123, false)]
    [InlineData("-123", DefaultNumberStyles, (sbyte)-123, false)]
    [InlineData("0", DefaultNumberStyles, (sbyte)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableSByte_WhenGivenAnSByteStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        sbyte? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableSByte(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (sbyte)123, false)]
    [InlineData("-123", (sbyte)-123, false)]
    [InlineData("0", (sbyte)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableSByte_WhenGivenAnSByteStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       sbyte? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableSByte(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (sbyte)123, false)]
    [InlineData("-123", DefaultNumberStyles, (sbyte)-123, false)]
    [InlineData("0", DefaultNumberStyles, (sbyte)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableSByte_WhenGivenAnSByteStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       sbyte? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableSByte(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }
}
