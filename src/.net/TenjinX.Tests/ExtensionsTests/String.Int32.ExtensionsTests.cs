using AwesomeAssertions;
using System.Globalization;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StringInt32ExtensionsTests
{
    private const NumberStyles DefaultNumberStyles = NumberStyles.Integer;

    [Theory]
    [InlineData("123", 123)]
    [InlineData("-123", -123)]
    [InlineData("0", 0)]
    public static void ParseAsInt32_WehnGivenOnlyAValidInt32String_ReturnsTheExpectedValue
    (
        string input,
        int expected
    )
    {
        var result = input.ParseAsInt32();

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsInt32_WhenGivenAnInvalidInt32String_ThrowsFormatException()
    {
        var input = "abc";
        var action = () => input.ParseAsInt32();

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, 123)]
    [InlineData(" -123  ", DefaultNumberStyles, -123)]
    public static void ParseAsInt32_WhenGivenAnInt32StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        int expected
    )
    {
        var result = input.ParseAsInt32(styles);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsInt32_WhenGivenAnInvalidInt32StringWithNumberStyle_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var action = () => input.ParseAsInt32(styles);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", 123)]
    [InlineData("-123", -123)]
    [InlineData("0", 0)]
    public static void ParseAsInt32_WhenGivenAnInt32StringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        int expected
    )
    {
        var result = input.ParseAsInt32(CultureInfo.CurrentCulture);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsInt32_WhenGivenAnInvalidInt32StringWithFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsInt32(provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, 123)]
    [InlineData(" -123  ", DefaultNumberStyles, -123)]
    public static void ParseAsInt32_WhenGivenAnInt32StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        int expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsInt32(styles, provider);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsInt32_WhenGivenAnInvalidInt32StringWithNumberStyleAndFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsInt32(styles, provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", 123)]
    [InlineData("-123", -123)]
    [InlineData("0", 0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableInt32_WhenGivenOnlyAValidInt32String_ReturnsTheExpectedValue
    (
        string? input,
        int? expected
    )
    {
        var result = input.ParseAsNullableInt32();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, 123)]
    [InlineData(" -123  ", DefaultNumberStyles, -123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableInt32_WhenGivenAnInt32StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        int? expected
    )
    {
        var result = input.ParseAsNullableInt32(styles);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", 123)]
    [InlineData("-123", -123)]
    [InlineData("0", 0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableInt32_WhenGivenAnInt32WithFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        int? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableInt32(provider);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, 123)]
    [InlineData(" -123  ", DefaultNumberStyles, -123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableInt32_WhenGivenAnInt32StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        int? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableInt32(styles, provider);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", 123, true)]
    [InlineData("-123", -123, true)]
    [InlineData("0", 0, true)]
    [InlineData("", 0, false)]
    [InlineData("invalid", 0, false)]
    public static void TryParseAsInt32_WhenGivenAnInt32String_ReturnsTheExpectedValue
    (
        string input,
        int expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsInt32(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, 123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, -123, true)]
    [InlineData("0", DefaultNumberStyles, 0, true)]
    [InlineData("", DefaultNumberStyles, 0, false)]
    [InlineData("invalid", DefaultNumberStyles, 0, false)]
    public static void TryParseAsInt32_WhenGivenAnInt32StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        int expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsInt32(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", 123, true)]
    [InlineData("-123", -123, true)]
    [InlineData("0", 0, true)]
    [InlineData("", 0, false)]
    [InlineData("invalid", 0, false)]
    public static void TryParseAsInt32_WhenGivenAnInt32StringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        int expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsInt32(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, 123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, -123, true)]
    [InlineData("0", DefaultNumberStyles, 0, true)]
    [InlineData("", DefaultNumberStyles, 0, false)]
    [InlineData("invalid", DefaultNumberStyles, 0, false)]
    public static void TryParseAsInt32_WhenGivenAnInt32StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        int expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsInt32(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", 123, true)]
    [InlineData("-123", -123, true)]
    [InlineData("0", 0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableInt32_WhenGivenAnInt32String_ReturnsTheExpectedValue
    (
        string? input,
        int? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableInt32(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, 123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, -123, true)]
    [InlineData("0", DefaultNumberStyles, 0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    [InlineData(null, DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableInt32_WhenGivenAnInt32StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        int? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableInt32(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", 123, true)]
    [InlineData("-123", -123, true)]
    [InlineData("0", 0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableInt32_WhenGivenAnInt32StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       int? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableInt32(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, 123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, -123, true)]
    [InlineData("0", DefaultNumberStyles, 0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableInt32_WhenGivenAnInt32StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       int? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableInt32(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", 123, false)]
    [InlineData("-123", -123, false)]
    [InlineData("0", 0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsInt32_WhenGivenAnInt32String_ReturnsTheExpectedValue
    (
        string input,
        int expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsInt32(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, 123, false)]
    [InlineData("-123", DefaultNumberStyles, -123, false)]
    [InlineData("0", DefaultNumberStyles, 0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsInt32_WhenGivenAnInt32StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        int expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsInt32(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", 123, false)]
    [InlineData("-123", -123, false)]
    [InlineData("0", 0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsInt32_WhenGivenAnInt32StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       int expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsInt32(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, 123, false)]
    [InlineData("-123", DefaultNumberStyles, -123, false)]
    [InlineData("0", DefaultNumberStyles, 0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsInt32_WhenGivenAnInt32StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       NumberStyles styles,
       int expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsInt32(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", 123, false)]
    [InlineData("-123", -123, false)]
    [InlineData("0", 0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableInt32_WhenGivenAnInt32String_ReturnsTheExpectedValue
    (
        string? input,
        int? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableInt32(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, 123, false)]
    [InlineData("-123", DefaultNumberStyles, -123, false)]
    [InlineData("0", DefaultNumberStyles, 0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableInt32_WhenGivenAnInt32StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        int? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableInt32(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", 123, false)]
    [InlineData("-123", -123, false)]
    [InlineData("0", 0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableInt32_WhenGivenAnInt32StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       int? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableInt32(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, 123, false)]
    [InlineData("-123", DefaultNumberStyles, -123, false)]
    [InlineData("0", DefaultNumberStyles, 0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableInt32_WhenGivenAnInt32StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       int? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableInt32(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }
}
