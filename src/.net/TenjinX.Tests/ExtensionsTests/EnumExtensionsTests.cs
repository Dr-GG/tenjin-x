using AwesomeAssertions;
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
}
