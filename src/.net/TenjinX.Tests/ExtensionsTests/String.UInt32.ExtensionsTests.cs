using AwesomeAssertions;
using System.Globalization;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StringUInt32ExtensionsTests
{
    private const NumberStyles DefaultNumberStyles = NumberStyles.Integer;

    [Theory]
    [InlineData("123", (uint)123)]
    [InlineData("0", (uint)0)]
    public static void ParseAsUInt32_WehnGivenOnlyAValidUInt32String_ReturnsTheExpectedValue
    (
        string input,
        uint expected
    )
    {
        var result = input.ParseAsUInt32();

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsUInt32_WhenGivenAnInvalidUInt32String_ThrowsFormatException()
    {
        var input = "abc";
        var action = () => input.ParseAsUInt32();

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (uint)123)]
    public static void ParseAsUInt32_WhenGivenAnUInt32StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        uint expected
    )
    {
        var result = input.ParseAsUInt32(styles);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsUInt32_WhenGivenAnInvalidUInt32StringWithNumberStyle_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var action = () => input.ParseAsUInt32(styles);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", (uint)123)]
    [InlineData("0", (uint)0)]
    public static void ParseAsUInt32_WhenGivenAnUInt32StringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        uint expected
    )
    {
        var result = input.ParseAsUInt32(CultureInfo.CurrentCulture);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsUInt32_WhenGivenAnInvalidUInt32StringWithFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsUInt32(provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (uint)123)]
    public static void ParseAsUInt32_WhenGivenAnUInt32StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        uint expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsUInt32(styles, provider);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsUInt32_WhenGivenAnInvalidUInt32StringWithNumberStyleAndFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsUInt32(styles, provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", (uint)123)]
    [InlineData("0", (uint)0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableUInt32_WhenGivenOnlyAValidUInt32String_ReturnsTheExpectedValue
    (
        string? input,
        uint? expected
    )
    {
        var result = input.ParseAsNullableUInt32();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (uint)123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableUInt32_WhenGivenAnUInt32StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        uint? expected
    )
    {
        var result = input.ParseAsNullableUInt32(styles);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", (uint)123)]
    [InlineData("0", (uint)0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableUInt32_WhenGivenAnUInt32WithFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        uint? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableUInt32(provider);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (uint)123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableUInt32_WhenGivenAnUInt32StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        uint? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableUInt32(styles, provider);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", (uint)123, true)]
    [InlineData("0", (uint)0, true)]
    [InlineData("", (uint)0, false)]
    [InlineData("invalid", (uint)0, false)]
    public static void TryParseAsUInt32_WhenGivenAnUInt32String_ReturnsTheExpectedValue
    (
        string input,
        uint expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsUInt32(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (uint)123, true)]
    [InlineData("0", DefaultNumberStyles, (uint)0, true)]
    [InlineData("", DefaultNumberStyles, (uint)0, false)]
    [InlineData("invalid", DefaultNumberStyles, (uint)0, false)]
    public static void TryParseAsUInt32_WhenGivenAnUInt32StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        uint expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsUInt32(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (uint)123, true)]
    [InlineData("0", (uint)0, true)]
    [InlineData("", (uint)0, false)]
    [InlineData("invalid", (uint)0, false)]
    public static void TryParseAsUInt32_WhenGivenAnUInt32StringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        uint expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsUInt32(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (uint)123, true)]
    [InlineData("0", DefaultNumberStyles, (uint)0, true)]
    [InlineData("", DefaultNumberStyles, (uint)0, false)]
    [InlineData("invalid", DefaultNumberStyles, (uint)0, false)]
    public static void TryParseAsUInt32_WhenGivenAnUInt32StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        uint expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsUInt32(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (uint)123, true)]
    [InlineData("0", (uint)0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableUInt32_WhenGivenAnUInt32String_ReturnsTheExpectedValue
    (
        string? input,
        uint? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableUInt32(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (uint)123, true)]
    [InlineData("0", DefaultNumberStyles, (uint)0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    [InlineData(null, DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableUInt32_WhenGivenAnUInt32StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        uint? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableUInt32(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (uint)123, true)]
    [InlineData("0", (uint)0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableUInt32_WhenGivenAnUInt32StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       uint? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableUInt32(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (uint)123, true)]
    [InlineData("0", DefaultNumberStyles, (uint)0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableUInt32_WhenGivenAnUInt32StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       uint? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableUInt32(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (uint)123, false)]
    [InlineData("0", (uint)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsUInt32_WhenGivenAnUInt32String_ReturnsTheExpectedValue
    (
        string input,
        uint expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsUInt32(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (uint)123, false)]
    [InlineData("0", DefaultNumberStyles, (uint)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsUInt32_WhenGivenAnUInt32StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        uint expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsUInt32(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (uint)123, false)]
    [InlineData("0", (uint)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsUInt32_WhenGivenAnUInt32StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       uint expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsUInt32(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (uint)123, false)]
    [InlineData("0", DefaultNumberStyles, (uint)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsUInt32_WhenGivenAnUInt32StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       NumberStyles styles,
       uint expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsUInt32(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (uint)123, false)]
    [InlineData("0", (uint)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableUInt32_WhenGivenAnUInt32String_ReturnsTheExpectedValue
    (
        string? input,
        uint? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableUInt32(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (uint)123, false)]
    [InlineData("0", DefaultNumberStyles, (uint)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableUInt32_WhenGivenAnUInt32StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        uint? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableUInt32(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (uint)123, false)]
    [InlineData("0", (uint)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableUInt32_WhenGivenAnUInt32StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       uint? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableUInt32(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (uint)123, false)]
    [InlineData("0", DefaultNumberStyles, (uint)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableUInt32_WhenGivenAnUInt32StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       uint? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableUInt32(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }
}
