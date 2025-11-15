using FluentAssertions;
using TenjinX.Implementations.Providers;

namespace TenjinX.Tests.ImplementationsTests.ProviderTests;

public static class TenjinUtcSystemClockProviderTests
{
    [Fact]
    public static void Now_WhenCalled_ReturnsCurrentUtcDateTime()
    {
        var provider = new TenjinUtcSystemClockProvider();
        var beforeCall = DateTime.UtcNow;
        var result = provider.Now();
        var afterCall = DateTime.UtcNow;

        result.Should().BeOnOrAfter(beforeCall);
        result.Should().BeOnOrBefore(afterCall);
    }
}
