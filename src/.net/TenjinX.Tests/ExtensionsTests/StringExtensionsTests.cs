using FluentAssertions;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StringExtensionsTests
{
    public const string TestString = "Hello, World!";
    public const string EmptyString = "";
    public const string WhiteSpaceString = "   ";
    public const string WhiteSpaceStringWithContent = "  Hello  ";

    [Theory]
    [InlineData(null, true)]
    [InlineData(EmptyString, true)]
    [InlineData(WhiteSpaceString, false)]
    [InlineData(TestString, false)]
    [InlineData(WhiteSpaceStringWithContent, false)]
    public static void IsNullOrEmpty_GivenParameters_EqualsTheExpectedResult(string? input, bool expected)
    {
        var result = input.IsNullOrEmpty();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, false)]
    [InlineData(EmptyString, false)]
    [InlineData(WhiteSpaceString, false)]
    [InlineData(TestString, true)]
    [InlineData(WhiteSpaceStringWithContent, true)]
    public static void IsNotNullAndEmpty_GivenParameters_EqualsTheExpectedResult(string? input, bool expected)
    {
        var result = input.IsNotNullAndEmpty();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, true)]
    [InlineData(EmptyString, true)]
    [InlineData(WhiteSpaceString, true)]
    [InlineData(TestString, false)]
    [InlineData(WhiteSpaceStringWithContent, false)]
    public static void IsNullOrWhiteSpace_GivenParameters_EqualsTheExpectedResult(string? input, bool expected)
    {
        var result = input.IsNullOrWhiteSpace();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, false)]
    [InlineData(EmptyString, false)]
    [InlineData(WhiteSpaceString, false)]
    [InlineData(TestString, true)]
    [InlineData(WhiteSpaceStringWithContent, true)]
    public static void IsNotNullAndWhiteSpace_GivenParameters_EqualsTheExpectedResult(string? input, bool expected)
    {
        var result = input.IsNotNullAndWhiteSpace();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(EmptyString, true)]
    [InlineData(TestString, false)]
    [InlineData(WhiteSpaceString, false)]
    [InlineData(WhiteSpaceStringWithContent, false)]
    public static void IsEmpty_GivenParameters_EqualsTheExpectedResult(string input, bool expected)
    {
        var result = input.IsEmpty();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(EmptyString, false)]
    [InlineData(TestString, true)]
    [InlineData(WhiteSpaceString, true)]
    [InlineData(WhiteSpaceStringWithContent, true)]
    public static void IsNotEmpty_GivenParameters_EqualsTheExpectedResult(string input, bool expected)
    {
        var result = input.IsNotEmpty();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(EmptyString, true)]
    [InlineData(WhiteSpaceString, true)]
    [InlineData(TestString, false)]
    [InlineData(WhiteSpaceStringWithContent, false)]
    public static void IsEmptyOrWhiteSpace_GivenParameters_EqualsTheExpectedResult(string input, bool expected)
    {
        var result = input.IsEmptyOrWhiteSpace();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(EmptyString, false)]
    [InlineData(WhiteSpaceString, false)]
    [InlineData(TestString, true)]
    [InlineData(WhiteSpaceStringWithContent, true)]
    public static void IsNotEmptyOrWhiteSpace_GivenParameters_EqualsTheExpectedResult(string input, bool expected)
    {
        var result = input.IsNotEmptyOrWhiteSpace();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("hello", "HELLO", true)]
    [InlineData("Hello, World!", "hello, world!", true)]
    [InlineData("TestString", "TestString", true)]
    [InlineData("Different", "different!", false)]
    [InlineData("", "", true)]
    public static void EqualsOrdinalIgnoreCase_GivenParameters_EqualsTheExpectedResult(string left, string right, bool expected)
    {
        var result = left.EqualsOrdinalIgnoreCase(right);

        result.Should().Be(expected);
    }
}
