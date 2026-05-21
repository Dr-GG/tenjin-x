using AwesomeAssertions;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class StringGuidExtensionsTests
{
    [Theory]
    [InlineData("{1C4804C7-9C13-4147-A175-82E95273EABD}")]
    [InlineData("03752A8A-FB5D-4DB1-A0F9-1F5C466F31FB")]
    [InlineData("{df2f69ab-858e-449f-8f73-b9cee82a4d7a}")]
    [InlineData("8a1fdcfa-ae27-4867-979c-45f7a9f83fd7")]
    public static void ParseAsGuid_WehnGivenOnlyAValidGuidString_ReturnsTheExpectedValue(string input)
    {
        var result = input.ParseAsGuid();
        var expected = Guid.Parse(input);

        result.Should().Be(expected);
    }

    [Fact]
    public static void ParseAsGuid_WhenGivenAnInvalidGuidString_ThrowsFormatException()
    {
        var input = "not a guid";
        var action = () => input.ParseAsGuid();

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("{1C4804C7-9C13-4147-A175-82E95273EABD}")]
    [InlineData("03752A8A-FB5D-4DB1-A0F9-1F5C466F31FB")]
    [InlineData("{df2f69ab-858e-449f-8f73-b9cee82a4d7a}")]
    [InlineData("8a1fdcfa-ae27-4867-979c-45f7a9f83fd7")]
    [InlineData("")]
    [InlineData(null)]
    public static void ParseAsNullableGuid_WhenGivenAValidGuidString_ReturnsTheExpectedValue(string input)
    {
        var result = input.ParseAsNullableGuid();
        var expected = input.IsNullOrEmpty()
            ? (Guid?)null
            : Guid.Parse(input);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("{1C4804C7-9C13-4147-A175-82E95273EABD}")]
    [InlineData("03752A8A-FB5D-4DB1-A0F9-1F5C466F31FB")]
    [InlineData("{df2f69ab-858e-449f-8f73-b9cee82a4d7a}")]
    [InlineData("8a1fdcfa-ae27-4867-979c-45f7a9f83fd7")]
    [InlineData("not a valid GUID")]
    [InlineData("")]
    public static void TryParseAsGuid_WhenGivenAValidGuidString_ReturnsTheExpectedValue(string input)
    {
        var result = input.TryParseAsGuid(out var parsedValue);
        var couldParse = Guid.TryParse(input, out var expected);

        result.Should().Be(couldParse);
        parsedValue.Should().Be(expected);
    }

    [Theory]
    [InlineData("{1C4804C7-9C13-4147-A175-82E95273EABD}")]
    [InlineData("03752A8A-FB5D-4DB1-A0F9-1F5C466F31FB")]
    [InlineData("{df2f69ab-858e-449f-8f73-b9cee82a4d7a}")]
    [InlineData("8a1fdcfa-ae27-4867-979c-45f7a9f83fd7")]
    [InlineData("not a valid GUID")]
    [InlineData("")]
    [InlineData(null)]
    public static void TryParseAsNullableGuid_WhenGivenAValidGuidString_ReturnsTheExpectedValue(string? input)
    {
        var output = Guid.Empty;
        var result = input.TryParseAsNullableGuid(out var parsedValue);
        var couldParse = input.IsNotNullAndEmpty() && Guid.TryParse(input, out output);
        var expected = couldParse ? output : (Guid?)null;

        result.Should().Be(couldParse);
        parsedValue.Should().Be(expected);
    }

    [Theory]
    [InlineData("{1C4804C7-9C13-4147-A175-82E95273EABD}")]
    [InlineData("03752A8A-FB5D-4DB1-A0F9-1F5C466F31FB")]
    [InlineData("{df2f69ab-858e-449f-8f73-b9cee82a4d7a}")]
    [InlineData("8a1fdcfa-ae27-4867-979c-45f7a9f83fd7")]
    [InlineData("not a valid GUID")]
    [InlineData("")]
    public static void TryFailParseAsGuid_WhenGivenAValidGuidString_ReturnsTheExpectedValue(string input)
    {
        var result = input.TryFailParseAsGuid(out var parsedValue);
        var couldParse = Guid.TryParse(input, out var expected);

        result.Should().Be(!couldParse);
        parsedValue.Should().Be(expected);
    }

    [Theory]
    [InlineData("{1C4804C7-9C13-4147-A175-82E95273EABD}")]
    [InlineData("03752A8A-FB5D-4DB1-A0F9-1F5C466F31FB")]
    [InlineData("{df2f69ab-858e-449f-8f73-b9cee82a4d7a}")]
    [InlineData("8a1fdcfa-ae27-4867-979c-45f7a9f83fd7")]
    [InlineData("not a valid GUID")]
    [InlineData("")]
    [InlineData(null)]
    public static void TryFailParseAsNullableGuid_WhenGivenAValidGuidString_ReturnsTheExpectedValue(string? input)
    {
        var output = Guid.Empty;
        var result = input.TryFailParseAsNullableGuid(out var parsedValue);
        var couldParse = input.IsNotNullAndEmpty() && Guid.TryParse(input, out output);
        var expected = couldParse ? output : (Guid?)null;

        result.Should().Be(!couldParse);
        parsedValue.Should().Be(expected);
    }
}
