using AwesomeAssertions;
using System.Globalization;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StringByteExtensionsTests
{
    private const NumberStyles DefaultNumberStyles = NumberStyles.Integer;

    [Theory]
    [InlineData("123", (byte)123)]
    [InlineData("0", (byte)0)]
    public static void ParseAsByte_WehnGivenOnlyAValidByteString_ReturnsTheExpectedValue
    (
        string input,
        byte expected
    )
    {
        var result = input.ParseAsByte();

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsByte_WhenGivenAnInvalidByteString_ThrowsFormatException()
    {
        var input = "abc";
        var action = () => input.ParseAsByte();

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (byte)123)]
    public static void ParseAsByte_WhenGivenAnByteStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        byte expected
    )
    {
        var result = input.ParseAsByte(styles);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsByte_WhenGivenAnInvalidByteStringWithNumberStyle_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var action = () => input.ParseAsByte(styles);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", (byte)123)]
    [InlineData("0", (byte)0)]
    public static void ParseAsByte_WhenGivenAnByteStringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        byte expected
    )
    {
        var result = input.ParseAsByte(CultureInfo.CurrentCulture);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsByte_WhenGivenAnInvalidByteStringWithFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsByte(provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (byte)123)]
    public static void ParseAsByte_WhenGivenAnByteStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        byte expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsByte(styles, provider);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsByte_WhenGivenAnInvalidByteStringWithNumberStyleAndFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsByte(styles, provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", (byte)123)]
    [InlineData("0", (byte)0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableByte_WhenGivenOnlyAValidByteString_ReturnsTheExpectedValue
    (
        string? input,
        byte? expected
    )
    {
        var result = input.ParseAsNullableByte();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (byte)123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableByte_WhenGivenAnByteStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        byte? expected
    )
    {
        var result = input.ParseAsNullableByte(styles);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", (byte)123)]
    [InlineData("0", (byte)0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableByte_WhenGivenAnByteWithFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        byte? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableByte(provider);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (byte)123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableByte_WhenGivenAnByteStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        byte? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableByte(styles, provider);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", (byte)123, true)]
    [InlineData("0", (byte)0, true)]
    [InlineData("", (byte)0, false)]
    [InlineData("invalid", (byte)0, false)]
    public static void TryParseAsByte_WhenGivenAnByteString_ReturnsTheExpectedValue
    (
        string input,
        byte expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsByte(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (byte)123, true)]
    [InlineData("0", DefaultNumberStyles, (byte)0, true)]
    [InlineData("", DefaultNumberStyles, (byte)0, false)]
    [InlineData("invalid", DefaultNumberStyles, (byte)0, false)]
    public static void TryParseAsByte_WhenGivenAnByteStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        byte expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsByte(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (byte)123, true)]
    [InlineData("0", (byte)0, true)]
    [InlineData("", (byte)0, false)]
    [InlineData("invalid", (byte)0, false)]
    public static void TryParseAsByte_WhenGivenAnByteStringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        byte expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsByte(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (byte)123, true)]
    [InlineData("0", DefaultNumberStyles, (byte)0, true)]
    [InlineData("", DefaultNumberStyles, (byte)0, false)]
    [InlineData("invalid", DefaultNumberStyles, (byte)0, false)]
    public static void TryParseAsByte_WhenGivenAnByteStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        byte expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsByte(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (byte)123, true)]
    [InlineData("0", (byte)0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableByte_WhenGivenAnByteString_ReturnsTheExpectedValue
    (
        string? input,
        byte? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableByte(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (byte)123, true)]
    [InlineData("0", DefaultNumberStyles, (byte)0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    [InlineData(null, DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableByte_WhenGivenAnByteStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        byte? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableByte(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (byte)123, true)]
    [InlineData("0", (byte)0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableByte_WhenGivenAnByteStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       byte? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableByte(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (byte)123, true)]
    [InlineData("0", DefaultNumberStyles, (byte)0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableByte_WhenGivenAnByteStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       byte? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableByte(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (byte)123, false)]
    [InlineData("0", (byte)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsByte_WhenGivenAnByteString_ReturnsTheExpectedValue
    (
        string input,
        byte expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsByte(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (byte)123, false)]
    [InlineData("0", DefaultNumberStyles, (byte)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsByte_WhenGivenAnByteStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        byte expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsByte(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (byte)123, false)]
    [InlineData("0", (byte)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsByte_WhenGivenAnByteStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       byte expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsByte(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (byte)123, false)]
    [InlineData("0", DefaultNumberStyles, (byte)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsByte_WhenGivenAnByteStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       NumberStyles styles,
       byte expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsByte(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (byte)123, false)]
    [InlineData("0", (byte)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableByte_WhenGivenAnByteString_ReturnsTheExpectedValue
    (
        string? input,
        byte? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableByte(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (byte)123, false)]
    [InlineData("0", DefaultNumberStyles, (byte)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableByte_WhenGivenAnByteStringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        byte? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableByte(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (byte)123, false)]
    [InlineData("0", (byte)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableByte_WhenGivenAnByteStringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       byte? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableByte(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (byte)123, false)]
    [InlineData("0", DefaultNumberStyles, (byte)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableByte_WhenGivenAnByteStringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       byte? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableByte(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }
}
