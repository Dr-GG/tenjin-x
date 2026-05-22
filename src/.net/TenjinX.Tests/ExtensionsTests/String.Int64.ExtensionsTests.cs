using AwesomeAssertions;
using System.Globalization;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StringInt64ExtensionsTests
{
    private const NumberStyles DefaultNumberStyles = NumberStyles.Integer;

    [Theory]
    [InlineData("123", (long)123)]
    [InlineData("-123", (long)-123)]
    [InlineData("0", (long)0)]
    public static void ParseAsInt64_WehnGivenOnlyAValidInt64String_ReturnsTheExpectedValue
    (
        string input,
        long expected
    )
    {
        var result = input.ParseAsInt64();

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsInt64_WhenGivenAnInvalidInt64String_ThrowsFormatException()
    {
        var input = "abc";
        var action = () => input.ParseAsInt64();

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (long)123)]
    [InlineData(" -123  ", DefaultNumberStyles, (long)-123)]
    public static void ParseAsInt64_WhenGivenAnInt64StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        long expected
    )
    {
        var result = input.ParseAsInt64(styles);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsInt64_WhenGivenAnInvalidInt64StringWithNumberStyle_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var action = () => input.ParseAsInt64(styles);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", (long)123)]
    [InlineData("-123", (long)-123)]
    [InlineData("0", (long)0)]
    public static void ParseAsInt64_WhenGivenAnInt64StringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        long expected
    )
    {
        var result = input.ParseAsInt64(CultureInfo.CurrentCulture);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsInt64_WhenGivenAnInvalidInt64StringWithFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsInt64(provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (long)123)]
    [InlineData(" -123  ", DefaultNumberStyles, (long)-123)]
    public static void ParseAsInt64_WhenGivenAnInt64StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        long expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsInt64(styles, provider);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsInt64_WhenGivenAnInvalidInt64StringWithNumberStyleAndFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsInt64(styles, provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", (long)123)]
    [InlineData("-123", (long)-123)]
    [InlineData("0", (long)0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableInt64_WhenGivenOnlyAValidInt64String_ReturnsTheExpectedValue
    (
        string? input,
        long? expected
    )
    {
        var result = input.ParseAsNullableInt64();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (long)123)]
    [InlineData(" -123  ", DefaultNumberStyles, (long)-123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableInt64_WhenGivenAnInt64StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        long? expected
    )
    {
        var result = input.ParseAsNullableInt64(styles);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", (long)123)]
    [InlineData("-123", (long)-123)]
    [InlineData("0", (long)0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableInt64_WhenGivenAnInt64WithFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        long? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableInt64(provider);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (long)123)]
    [InlineData(" -123  ", DefaultNumberStyles, (long)-123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableInt64_WhenGivenAnInt64StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        long? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableInt64(styles, provider);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", (long)123, true)]
    [InlineData("-123", (long)-123, true)]
    [InlineData("0", (long)0, true)]
    [InlineData("", (long)0, false)]
    [InlineData("invalid", (long)0, false)]
    public static void TryParseAsInt64_WhenGivenAnInt64String_ReturnsTheExpectedValue
    (
        string input,
        long expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsInt64(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (long)123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, (long)-123, true)]
    [InlineData("0", DefaultNumberStyles, (long)0, true)]
    [InlineData("", DefaultNumberStyles, (long)0, false)]
    [InlineData("invalid", DefaultNumberStyles, (long)0, false)]
    public static void TryParseAsInt64_WhenGivenAnInt64StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        long expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsInt64(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (long)123, true)]
    [InlineData("-123", (long)-123, true)]
    [InlineData("0", (long)0, true)]
    [InlineData("", (long)0, false)]
    [InlineData("invalid", (long)0, false)]
    public static void TryParseAsInt64_WhenGivenAnInt64StringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        long expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsInt64(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (long)123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, (long)-123, true)]
    [InlineData("0", DefaultNumberStyles, (long)0, true)]
    [InlineData("", DefaultNumberStyles, (long)0, false)]
    [InlineData("invalid", DefaultNumberStyles, (long)0, false)]
    public static void TryParseAsInt64_WhenGivenAnInt64StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        long expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsInt64(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (long)123, true)]
    [InlineData("-123", (long)-123, true)]
    [InlineData("0", (long)0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableInt64_WhenGivenAnInt64String_ReturnsTheExpectedValue
    (
        string? input,
        long? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableInt64(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (long)123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, (long)-123, true)]
    [InlineData("0", DefaultNumberStyles, (long)0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    [InlineData(null, DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableInt64_WhenGivenAnInt64StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        long? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableInt64(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (long)123, true)]
    [InlineData("-123", (long)-123, true)]
    [InlineData("0", (long)0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableInt64_WhenGivenAnInt64StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       long? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableInt64(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (long)123, true)]
    [InlineData(" -123  ", DefaultNumberStyles, (long)-123, true)]
    [InlineData("0", DefaultNumberStyles, (long)0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableInt64_WhenGivenAnInt64StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       long? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableInt64(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (long)123, false)]
    [InlineData("-123", (long)-123, false)]
    [InlineData("0", (long)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsInt64_WhenGivenAnInt64String_ReturnsTheExpectedValue
    (
        string input,
        long expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsInt64(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (long)123, false)]
    [InlineData("-123", DefaultNumberStyles, (long)-123, false)]
    [InlineData("0", DefaultNumberStyles, (long)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsInt64_WhenGivenAnInt64StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        long expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsInt64(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (long)123, false)]
    [InlineData("-123", (long)-123, false)]
    [InlineData("0", (long)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsInt64_WhenGivenAnInt64StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       long expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsInt64(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (long)123, false)]
    [InlineData("-123", DefaultNumberStyles, (long)-123, false)]
    [InlineData("0", DefaultNumberStyles, (long)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsInt64_WhenGivenAnInt64StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       NumberStyles styles,
       long expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsInt64(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (long)123, false)]
    [InlineData("-123", (long)-123, false)]
    [InlineData("0", (long)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableInt64_WhenGivenAnInt64String_ReturnsTheExpectedValue
    (
        string? input,
        long? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableInt64(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (long)123, false)]
    [InlineData("-123", DefaultNumberStyles, (long)-123, false)]
    [InlineData("0", DefaultNumberStyles, (long)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableInt64_WhenGivenAnInt64StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        long? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableInt64(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (long)123, false)]
    [InlineData("-123", (long)-123, false)]
    [InlineData("0", (long)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableInt64_WhenGivenAnInt64StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       long? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableInt64(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (long)123, false)]
    [InlineData("-123", DefaultNumberStyles, (long)-123, false)]
    [InlineData("0", DefaultNumberStyles, (long)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableInt64_WhenGivenAnInt64StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       long? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableInt64(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }
}
