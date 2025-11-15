using FluentAssertions;
using TenjinX.Implementations.Providers;

namespace TenjinX.Tests.ImplementationsTests.ProviderTests;

public static class TenjinLocalSystemClockProviderTests
{
    [Fact]
    public static void Now_WhenCalled_ReturnsCurrentLocalDateTime()
    {
        var provider = new TenjinLocalSystemClockProvider();
        var beforeCall = DateTime.Now;
        var result = provider.Now();
        var afterCall = DateTime.Now;
        
        result.Should().BeOnOrAfter(beforeCall);
        result.Should().BeOnOrBefore(afterCall);
    }
}
