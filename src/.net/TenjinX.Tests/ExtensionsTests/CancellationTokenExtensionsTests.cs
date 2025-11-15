using FluentAssertions;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public class CancellationTokenExtensionsTests
{
    private readonly CancellationTokenSource _tokenSource = new();

    [Fact]
    public void CanContinue_ShouldReturnTrue_WhenNotCancelled()
    {
        var token = _tokenSource.Token;
        var result = token.CanContinue();

        result.Should().BeTrue();
    }

    [Fact]
    public void CanContinue_ShouldReturnFalse_WhenCancelled()
    {
        _tokenSource.Cancel();
        var token = _tokenSource.Token;
        var result = token.CanContinue();

        result.Should().BeFalse();
    }

    [Fact]
    public void CannotContinue_ShouldReturnFalse_WhenNotCancelled()
    {
        var token = _tokenSource.Token;
        var result = token.CannotContinue();

        result.Should().BeFalse();
    }

    [Fact]
    public void CannotContinue_ShouldReturnTrue_WhenCancelled()
    {
        _tokenSource.Cancel();
        var token = _tokenSource.Token;
        var result = token.CannotContinue();

        result.Should().BeTrue();
    }
}
