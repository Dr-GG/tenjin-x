using AwesomeAssertions;
using System.Globalization;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StringUInt16ExtensionsTests
{
    private const NumberStyles DefaultNumberStyles = NumberStyles.Integer;

    [Theory]
    [InlineData("123", (ushort)123)]
    [InlineData("0", (ushort)0)]
    public static void ParseAsUInt16_WehnGivenOnlyAValidUInt16String_ReturnsTheExpectedValue
    (
        string input,
        ushort expected
    )
    {
        var result = input.ParseAsUInt16();

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsUInt16_WhenGivenAnInvalidUInt16String_ThrowsFormatException()
    {
        var input = "abc";
        var action = () => input.ParseAsUInt16();

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ushort)123)]
    public static void ParseAsUInt16_WhenGivenAnUInt16StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        ushort expected
    )
    {
        var result = input.ParseAsUInt16(styles);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsUInt16_WhenGivenAnInvalidUInt16StringWithNumberStyle_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var action = () => input.ParseAsUInt16(styles);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", (ushort)123)]
    [InlineData("0", (ushort)0)]
    public static void ParseAsUInt16_WhenGivenAnUInt16StringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        ushort expected
    )
    {
        var result = input.ParseAsUInt16(CultureInfo.CurrentCulture);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsUInt16_WhenGivenAnInvalidUInt16StringWithFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsUInt16(provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ushort)123)]
    public static void ParseAsUInt16_WhenGivenAnUInt16StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        ushort expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsUInt16(styles, provider);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsUInt16_WhenGivenAnInvalidUInt16StringWithNumberStyleAndFormatProvider_ThrowsFormatException()
    {
        var input = "abc";
        var styles = NumberStyles.Integer;
        var provider = CultureInfo.CurrentCulture;
        var action = () => input.ParseAsUInt16(styles, provider);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("123", (ushort)123)]
    [InlineData("0", (ushort)0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableUInt16_WhenGivenOnlyAValidUInt16String_ReturnsTheExpectedValue
    (
        string? input,
        ushort? expected
    )
    {
        var result = input.ParseAsNullableUInt16();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ushort)123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableUInt16_WhenGivenAnUInt16StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        ushort? expected
    )
    {
        var result = input.ParseAsNullableUInt16(styles);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", (ushort)123)]
    [InlineData("0", (ushort)0)]
    [InlineData("", null)]
    [InlineData("invalid", null)]
    [InlineData(null, null)]
    public static void ParseAsNullableUInt16_WhenGivenAnUInt16WithFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        ushort? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableUInt16(provider);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ushort)123)]
    [InlineData("", DefaultNumberStyles, null)]
    [InlineData("invalid", DefaultNumberStyles, null)]
    [InlineData(null, DefaultNumberStyles, null)]
    public static void ParseAsNullableUInt16_WhenGivenAnUInt16StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        ushort? expected
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.ParseAsNullableUInt16(styles, provider);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123", (ushort)123, true)]
    [InlineData("0", (ushort)0, true)]
    [InlineData("", (ushort)0, false)]
    [InlineData("invalid", (ushort)0, false)]
    public static void TryParseAsUInt16_WhenGivenAnUInt16String_ReturnsTheExpectedValue
    (
        string input,
        ushort expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsUInt16(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ushort)123, true)]
    [InlineData("0", DefaultNumberStyles, (ushort)0, true)]
    [InlineData("", DefaultNumberStyles, (ushort)0, false)]
    [InlineData("invalid", DefaultNumberStyles, (ushort)0, false)]
    public static void TryParseAsUInt16_WhenGivenAnUInt16StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        ushort expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsUInt16(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (ushort)123, true)]
    [InlineData("0", (ushort)0, true)]
    [InlineData("", (ushort)0, false)]
    [InlineData("invalid", (ushort)0, false)]
    public static void TryParseAsUInt16_WhenGivenAnUInt16StringWithFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        ushort expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsUInt16(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ushort)123, true)]
    [InlineData("0", DefaultNumberStyles, (ushort)0, true)]
    [InlineData("", DefaultNumberStyles, (ushort)0, false)]
    [InlineData("invalid", DefaultNumberStyles, (ushort)0, false)]
    public static void TryParseAsUInt16_WhenGivenAnUInt16StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        ushort expectedNumber,
        bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsUInt16(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (ushort)123, true)]
    [InlineData("0", (ushort)0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableUInt16_WhenGivenAnUInt16String_ReturnsTheExpectedValue
    (
        string? input,
        ushort? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableUInt16(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ushort)123, true)]
    [InlineData("0", DefaultNumberStyles, (ushort)0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    [InlineData(null, DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableUInt16_WhenGivenAnUInt16StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        ushort? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableUInt16(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (ushort)123, true)]
    [InlineData("0", (ushort)0, true)]
    [InlineData("", null, false)]
    [InlineData("invalid", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableUInt16_WhenGivenAnUInt16StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       ushort? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableUInt16(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("  123  ", DefaultNumberStyles, (ushort)123, true)]
    [InlineData("0", DefaultNumberStyles, (ushort)0, true)]
    [InlineData("", DefaultNumberStyles, null, false)]
    [InlineData("invalid", DefaultNumberStyles, null, false)]
    public static void TryParseAsNullableUInt16_WhenGivenAnUInt16StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       ushort? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryParseAsNullableUInt16(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (ushort)123, false)]
    [InlineData("0", (ushort)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsUInt16_WhenGivenAnUInt16String_ReturnsTheExpectedValue
    (
        string input,
        ushort expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsUInt16(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (ushort)123, false)]
    [InlineData("0", DefaultNumberStyles, (ushort)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsUInt16_WhenGivenAnUInt16StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string input,
        NumberStyles styles,
        ushort expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsUInt16(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (ushort)123, false)]
    [InlineData("0", (ushort)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    public static void TryFailParseAsUInt16_WhenGivenAnUInt16StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       ushort expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsUInt16(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (ushort)123, false)]
    [InlineData("0", DefaultNumberStyles, (ushort)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    public static void TryFailParseAsUInt16_WhenGivenAnUInt16StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string input,
       NumberStyles styles,
       ushort expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsUInt16(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (ushort)123, false)]
    [InlineData("0", (ushort)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableUInt16_WhenGivenAnUInt16String_ReturnsTheExpectedValue
    (
        string? input,
        ushort? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableUInt16(out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (ushort)123, false)]
    [InlineData("0", DefaultNumberStyles, (ushort)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableUInt16_WhenGivenAnUInt16StringWithNumberStyle_ReturnsTheExpectedValue
    (
        string? input,
        NumberStyles styles,
        ushort? expectedNumber,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableUInt16(styles, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", (ushort)123, false)]
    [InlineData("0", (ushort)0, false)]
    [InlineData("", null, true)]
    [InlineData("invalid", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableUInt16_WhenGivenAnUInt16StringWithFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       ushort? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableUInt16(provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }

    [Theory]
    [InlineData("123", DefaultNumberStyles, (ushort)123, false)]
    [InlineData("0", DefaultNumberStyles, (ushort)0, false)]
    [InlineData("", DefaultNumberStyles, null, true)]
    [InlineData("invalid", DefaultNumberStyles, null, true)]
    [InlineData(null, DefaultNumberStyles, null, true)]
    public static void TryFailParseAsNullableUInt16_WhenGivenAnUInt16StringWithNumberStyleAndFormatProvider_ReturnsTheExpectedValue
    (
       string? input,
       NumberStyles styles,
       ushort? expectedNumber,
       bool expectedResult
    )
    {
        var provider = CultureInfo.CurrentCulture;
        var result = input.TryFailParseAsNullableUInt16(styles, provider, out var number);

        result.Should().Be(expectedResult);
        number.Should().Be(expectedNumber);
    }
}
