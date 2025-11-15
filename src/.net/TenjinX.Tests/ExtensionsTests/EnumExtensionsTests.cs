using FluentAssertions;
using TenjinX.Exceptions;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class EnumExtensionsTests
{
    public enum TestBitwiseEnum
    {
        None = 0,
        First = 1,
        Second = 2,
        Third = 4,
        Fourth = 8,
        Fifth = 16,
        All = First | Second | Third | Fourth | Fifth
    }

    [Fact]
    public static void GetFlags_WhenGivenBitwiseEnum_ReturnsExpectedFlags()
    {
        var enumValue = TestBitwiseEnum.First | TestBitwiseEnum.Third | TestBitwiseEnum.Fifth;
        var flags = enumValue.GetFlags();

        flags.Should().BeEquivalentTo
        (
            [
                TestBitwiseEnum.First,
                TestBitwiseEnum.Third,
                TestBitwiseEnum.Fifth
            ]
        );
    }

    [Fact]
    public static void MergeFlags_WhenGivenEnumFlags_ReturnsMergedEnum()
    {
        var expectedEnum = TestBitwiseEnum.Second | TestBitwiseEnum.Fourth;
        var flags = new[]
        {
            TestBitwiseEnum.Second,
            TestBitwiseEnum.Fourth
        };
        var mergedEnum = flags.MergeFlags();

        mergedEnum.Should().Be(expectedEnum);
    }

    [Theory]
    [InlineData("None", TestBitwiseEnum.None)]
    [InlineData("First", TestBitwiseEnum.First)]
    [InlineData("Second", TestBitwiseEnum.Second)]
    [InlineData("Third", TestBitwiseEnum.Third)]
    [InlineData("none", TestBitwiseEnum.None)]
    [InlineData("first", TestBitwiseEnum.First)]
    [InlineData("second", TestBitwiseEnum.Second)]
    [InlineData("third", TestBitwiseEnum.Third)]
    [InlineData("NONE", TestBitwiseEnum.None)]
    [InlineData("FIRST", TestBitwiseEnum.First)]
    [InlineData("SECOND", TestBitwiseEnum.Second)]
    [InlineData("THIRD", TestBitwiseEnum.Third)]
    public static void ParseAsEnum_WhenGivenValidString_ReturnsParsedEnum(string value, TestBitwiseEnum expectedEnum)
    {
        var parsedEnum = value.ParseAsEnum<TestBitwiseEnum>();

        parsedEnum.Should().Be(expectedEnum);
    }

    [Fact]
    public static void ParseAsEnum_WhenGivenInvalidString_ThrowsException()
    {
        Action act = () => "Wrong".ParseAsEnum<TestBitwiseEnum>();

        act.Should().Throw<TenjinException>();
    }

    [Theory]
    [InlineData("Wrong", null, null)]
    [InlineData("Wrong", TestBitwiseEnum.Third, TestBitwiseEnum.Third)]
    [InlineData("Wrong", TestBitwiseEnum.Third, TestBitwiseEnum.Third)]
    [InlineData("None", TestBitwiseEnum.None, TestBitwiseEnum.None)]
    [InlineData("First", TestBitwiseEnum.None, TestBitwiseEnum.First)]
    [InlineData("Second", TestBitwiseEnum.None, TestBitwiseEnum.Second)]
    [InlineData("Third", TestBitwiseEnum.None, TestBitwiseEnum.Third)]
    [InlineData("none", TestBitwiseEnum.None, TestBitwiseEnum.None)]
    [InlineData("first", TestBitwiseEnum.None, TestBitwiseEnum.First)]
    [InlineData("second", TestBitwiseEnum.None, TestBitwiseEnum.Second)]
    [InlineData("third", TestBitwiseEnum.None, TestBitwiseEnum.Third)]
    [InlineData("NONE", TestBitwiseEnum.None, TestBitwiseEnum.None)]
    [InlineData("FIRST", TestBitwiseEnum.None, TestBitwiseEnum.First)]
    [InlineData("SECOND", TestBitwiseEnum.None, TestBitwiseEnum.Second)]
    [InlineData("THIRD", TestBitwiseEnum.None, TestBitwiseEnum.Third)]
    public static void ParseAsNullableEnum_WhenGivenCertainScenarios_ReturnsTheExpectedResult
    (
        string value,
        TestBitwiseEnum? defaultValue,
        TestBitwiseEnum? expectedEnum
    )
    {
        var parsedEnum = value.ParseAsNullableEnum(defaultValue);

        parsedEnum.Should().Be(expectedEnum);
    }

    [Theory]
    [InlineData("First", true, TestBitwiseEnum.First)]
    [InlineData("second", true, TestBitwiseEnum.Second)]
    [InlineData("THIRD", true, TestBitwiseEnum.Third)]
    [InlineData("", false, null)]
    [InlineData("Wrong", false, null)]
    public static void TryParseEnum_WhenGivenCertainScenarios_ReturnsTheExpectedResult
    (
        string value,
        bool expectedParsed,
        TestBitwiseEnum? parsedEnum
    )
    {
        var parsedResult = value.TryParseAsEnum<TestBitwiseEnum>(out var enumResult);

        parsedResult.Should().Be(expectedParsed);

        if (parsedResult)
        {
            enumResult.Should().Be(parsedEnum);
        }
    }
}
