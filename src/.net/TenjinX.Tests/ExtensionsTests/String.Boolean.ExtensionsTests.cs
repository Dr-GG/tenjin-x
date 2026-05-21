using AwesomeAssertions;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StringBooleanExtensionsTests
{
    [Theory]
    [InlineData("true", true)]
    [InlineData("TRUE", true)]
    [InlineData("false", false)]
    [InlineData("FALSE", false)]
    public static void ParseAsBoolean_WehnGivenOnlyAValidBooleanString_ReturnsTheExpectedValue
    (
        string input,
        bool expected
    )
    {
        var result = input.ParseAsBoolean();

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsBoolean_WhenGivenAnInvalidBooleanString_ThrowsFormatException()
    {
        var input = "not a boolean";
        var action = () => input.ParseAsBoolean();

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("true", true)]
    [InlineData("TRUE", true)]
    [InlineData("false", false)]
    [InlineData("FALSE", false)]
    [InlineData(null, null)]
    [InlineData("", null)]
    [InlineData("not a boolean", null)]
    public static void ParseAsNullableBoolean_WhenGivenAValidBooleanString_ReturnsTheExpectedValue
    (
        string input,
        bool? expected
    )
    {
        var result = input.ParseAsNullableBoolean();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("true", true, true)]
    [InlineData("TRUE", true, true)]
    [InlineData("false", false, true)]
    [InlineData("FALSE", false, true)]
    [InlineData("", false, false)]
    [InlineData("not a boolean", false, false)]
    public static void TryParseAsBoolean_WhenGivenAValidBooleanString_ReturnsTheExpectedValue
    (
        string input,
        bool expectedBoolean,
        bool expectedResult
    )
    {
        var result = input.TryParseAsBoolean(out var parsedValue);

        result.Should().Be(expectedResult);
        parsedValue.Should().Be(expectedBoolean);
    }

    [Theory]
    [InlineData("true", true, true)]
    [InlineData("TRUE", true, true)]
    [InlineData("false", false, true)]
    [InlineData("FALSE", false, true)]
    [InlineData("", null, false)]
    [InlineData("not a boolean", null, false)]
    [InlineData(null, null, false)]
    public static void TryParseAsNullableBoolean_WhenGivenAValidBooleanString_ReturnsTheExpectedValue
    (
        string input,
        bool? expectedBoolean,
        bool expectedResult
    )
    {
        var result = input.TryParseAsNullableBoolean(out var parsedValue);
        result.Should().Be(expectedResult);
        parsedValue.Should().Be(expectedBoolean);
    }

    [Theory]
    [InlineData("true", true, false)]
    [InlineData("TRUE", true, false)]
    [InlineData("false", false, false)]
    [InlineData("FALSE", false, false)]
    [InlineData("", null, true)]
    [InlineData("not a boolean", null, true)]
    public static void TryFailParseAsBoolean_WhenGivenAValidBooleanString_ReturnsTheExpectedValue
    (
        string input,
        bool expectedBoolean,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsBoolean(out var parsedValue);

        result.Should().Be(expectedResult);
        parsedValue.Should().Be(expectedBoolean);
    }

    [Theory]
    [InlineData("true", true, false)]
    [InlineData("TRUE", true, false)]
    [InlineData("false", false, false)]
    [InlineData("FALSE", false, false)]
    [InlineData("", null, true)]
    [InlineData("not a boolean", null, true)]
    [InlineData(null, null, true)]
    public static void TryFailParseAsNullableBoolean_WhenGivenAValidBooleanString_ReturnsTheExpectedValue
    (
        string input,
        bool? expectedBoolean,
        bool expectedResult
    )
    {
        var result = input.TryFailParseAsNullableBoolean(out var parsedValue);
        result.Should().Be(expectedResult);
        parsedValue.Should().Be(expectedBoolean);
    }
}
