using FluentAssertions;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class ObjectExtensionsTests
{
    [Fact]
    public static void DoesNotEqual_WhenObjectsAreNotEqual_ShouldReturnTrue()
    {
        var obj1 = new { Name = "Alice" };
        var obj2 = new { Name = "Bob" };
        var leftToRightResult = obj1.DoesNotEqual(obj2);
        var rightToLeftResult = obj2.DoesNotEqual(obj1);

        leftToRightResult.Should().BeTrue();
        rightToLeftResult.Should().BeTrue();
    }

    [Fact]
    public static void DoesNotEqual_WhenObjectsAreEqual_ShouldReturnFalse()
    {
        var obj1 = new { Name = "Alice" };
        var obj2 = new { Name = "Alice" };
        var leftToRightResult = obj1.DoesNotEqual(obj2);
        var rightToLeftResult = obj2.DoesNotEqual(obj1);

        leftToRightResult.Should().BeFalse();
        rightToLeftResult.Should().BeFalse();
    }
}
