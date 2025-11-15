using FluentAssertions;
using Moq;
using TenjinX.Exceptions;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class TypeExtensionsTests
{
    [Fact]
    public static void GetFullName_WhenHasFullName_ReturnsFullName()
    {
        var type = typeof(string);
        var fullName = type.GetFullName();

        fullName.Should().Be("System.String");
    }

    [Fact]
    public static void GetFullName_WhenNoFullName_ThrowsTenjinException()
    {
        var mockType = new Mock<Type>();
        var act = mockType.Object.GetFullName;

        mockType
            .SetupGet(t => t.FullName)
            .Returns((string?)null);

        act.Should().Throw<TenjinException>();
    }
}
