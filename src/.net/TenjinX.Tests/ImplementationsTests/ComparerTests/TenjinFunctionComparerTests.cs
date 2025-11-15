using FluentAssertions;
using TenjinX.Implementations.Comparers;

namespace TenjinX.Tests.ImplementationsTests.ComparerTests;

public class TenjinFunctionComparerTests
{
    private readonly TenjinFunctionComparer<int> _comparer = new((x, y) => x.CompareTo(y));

    [Theory]
    [InlineData(null, null, 0)]
    [InlineData(null, 5, -1)]
    [InlineData(5, null, 1)]
    [InlineData(3, 5, -1)]
    [InlineData(5, 3, 1)]
    [InlineData(3, 3, 0)]
    public void Compare_ObjectValues_ReturnsExpectedResult(object? x, object? y, int expected)
    {
        var result = _comparer.Compare(x, y);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(3, 5, -1)]
    [InlineData(5, 3, 1)]
    [InlineData(3, 3, 0)]
    public void Compare_GenericValues_ReturnsExpectedResult(int x, int y, int expected)
    {
        var result = _comparer.Compare(x, y);

        result.Should().Be(expected);
    }
}
