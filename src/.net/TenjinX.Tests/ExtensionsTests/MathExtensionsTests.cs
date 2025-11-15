using FluentAssertions;
using TenjinX.Extensions;

namespace TenjinX.Tests.ExtensionsTests;

public static class MathExtensionsTests
{
    [Fact]
    public static void EqualsWithinTolerance_WithFloatsAndWithinTolerance_ShouldReturnTrue()
    {
        float a = 0.1f + 0.2f;
        float b = 0.3f;

        a.EqualsWithinTolerance(b).Should().BeTrue();
    }

    [Fact]
    public static void EqualsWithinTolerance_WithFloatsAndCustomToleranceAndWithinTolerance__ShouldReturnTrue()
    {
        float a = 0.1f + 0.2f;
        float b = 0.30005f;

        a.EqualsWithinTolerance(b, 0.0001f).Should().BeTrue();
    }

    [Fact]
    public static void EqualsWithinTolerance_WithFloatsAndOutsideTolerance_ShouldReturnFalse()
    {
        float a = 0.1f + 0.2f;
        float b = 0.4f;

        a.EqualsWithinTolerance(b).Should().BeFalse();
    }

    [Fact]
    public static void EqualsWithinTolerance_WithFloatsAndCustomToleranceAndOutsideTolerance_ShouldReturnFalse()
    {
        float a = 0.1f + 0.2f;
        float b = 0.3005f;

        a.EqualsWithinTolerance(b, 0.0001f).Should().BeFalse();
    }

    [Fact]
    public static void EqualsWithinTolerance_WithDoublesAndWithinTolerance_ShouldReturnTrue()
    {
        double a = 0.1 + 0.2;
        double b = 0.3;

        a.EqualsWithinTolerance(b).Should().BeTrue();
    }

    [Fact]
    public static void EqualsWithinTolerance_WithDoublesAndCustomToleranceAndWithinTolerance__ShouldReturnTrue()
    {
        double a = 0.1 + 0.2;
        double b = 0.30005;

        a.EqualsWithinTolerance(b, 0.0001).Should().BeTrue();
    }

    [Fact]
    public static void EqualsWithinTolerance_WithDoublesAndOutsideTolerance_ShouldReturnFalse()
    {
        double a = 0.1 + 0.2;
        double b = 0.4;

        a.EqualsWithinTolerance(b).Should().BeFalse();
    }

    [Fact]
    public static void EqualsWithinTolerance_WithDoublesAndCustomToleranceAndOutsideTolerance_ShouldReturnFalse()
    {
        double a = 0.1 + 0.2;
        double b = 0.3005;

        a.EqualsWithinTolerance(b, 0.0001).Should().BeFalse();
    }

    [Fact]
    public static void EqualsWithinTolerance_WithDecimalsAndWithinTolerance_ShouldReturnTrue()
    {
        decimal a = 0.1m + 0.2m;
        decimal b = 0.3m;

        a.EqualsWithinTolerance(b).Should().BeTrue();
    }

    [Fact]
    public static void EqualsWithinTolerance_WithDecimalsAndCustomToleranceAndWithinTolerance__ShouldReturnTrue()
    {
        decimal a = 0.1m + 0.2m;
        decimal b = 0.30005m;

        a.EqualsWithinTolerance(b, 0.0001m).Should().BeTrue();
    }

    [Fact]
    public static void EqualsWithinTolerance_WithDecimalsAndOutsideTolerance_ShouldReturnFalse()
    {
        decimal a = 0.1m + 0.2m;
        decimal b = 0.4m;

        a.EqualsWithinTolerance(b).Should().BeFalse();
    }

    [Fact]
    public static void EqualsWithinTolerance_WithDecimalsAndCustomToleranceAndOutsideTolerance_ShouldReturnFalse()
    {
        decimal a = 0.1m + 0.2m;
        decimal b = 0.3005m;

        a.EqualsWithinTolerance(b, 0.0001m).Should().BeFalse();
    }

    [Fact]
    public static void DoesNotEqualWithinTolerance_WithFloatsAndWithinTolerance_ShouldReturnFalse()
    {
        float a = 0.1f + 0.2f;
        float b = 0.3f;

        a.DoesNotEqualWithinTolerance(b).Should().BeFalse();
    }

    [Fact]
    public static void DoesNotEqualWithinTolerance_WithFloatsAndCustomToleranceAndWithinTolerance__ShouldReturnFalse()
    {
        float a = 0.1f + 0.2f;
        float b = 0.30005f;

        a.DoesNotEqualWithinTolerance(b, 0.0001f).Should().BeFalse();
    }

    [Fact]
    public static void DoesNotEqualWithinTolerance_WithFloatsAndOutsideTolerance_ShouldReturnTrue()
    {
        float a = 0.1f + 0.2f;
        float b = 0.4f;

        a.DoesNotEqualWithinTolerance(b).Should().BeTrue();
    }

    [Fact]
    public static void DoesNotEqualWithinTolerance_WithFloatsAndCustomToleranceAndOutsideTolerance_ShouldReturnTrue()
    {
        float a = 0.1f + 0.2f;
        float b = 0.3005f;

        a.DoesNotEqualWithinTolerance(b, 0.0001f).Should().BeTrue();
    }

    [Fact]
    public static void DoesNotEqualWithinTolerance_WithDoublesAndWithinTolerance_ShouldReturnFalse()
    {
        double a = 0.1 + 0.2;
        double b = 0.3;

        a.DoesNotEqualWithinTolerance(b).Should().BeFalse();
    }

    [Fact]
    public static void DoesNotEqualWithinTolerance_WithDoublesAndCustomToleranceAndWithinTolerance__ShouldReturnFalse()
    {
        double a = 0.1 + 0.2;
        double b = 0.30005;

        a.DoesNotEqualWithinTolerance(b, 0.0001).Should().BeFalse();
    }

    [Fact]
    public static void DoesNotEqualWithinTolerance_WithDoublesAndOutsideTolerance_ShouldReturnTrue()
    {
        double a = 0.1 + 0.2;
        double b = 0.4;

        a.DoesNotEqualWithinTolerance(b).Should().BeTrue();
    }

    [Fact]
    public static void DoesNotEqualWithinTolerance_WithDoublesAndCustomToleranceAndOutsideTolerance_ShouldReturnTrue()
    {
        double a = 0.1 + 0.2;
        double b = 0.3005;

        a.DoesNotEqualWithinTolerance(b, 0.0001).Should().BeTrue();
    }

    [Fact]
    public static void DoesNotEqualWithinTolerance_WithDecimalsAndWithinTolerance_ShouldReturnFalse()
    {
        decimal a = 0.1m + 0.2m;
        decimal b = 0.3m;

        a.DoesNotEqualWithinTolerance(b).Should().BeFalse();
    }

    [Fact]
    public static void DoesNotEqualWithinTolerance_WithDecimalsAndCustomToleranceAndWithinTolerance__ShouldReturnFalse()
    {
        decimal a = 0.1m + 0.2m;
        decimal b = 0.30005m;

        a.DoesNotEqualWithinTolerance(b, 0.0001m).Should().BeFalse();
    }

    [Fact]
    public static void DoesNotEqualWithinTolerance_WithDecimalsAndOutsideTolerance_ShouldReturnTrue()
    {
        decimal a = 0.1m + 0.2m;
        decimal b = 0.4m;

        a.DoesNotEqualWithinTolerance(b).Should().BeTrue();
    }

    [Fact]
    public static void DoesNotEqualWithinTolerance_WithDecimalsAndCustomToleranceAndOutsideTolerance_ShouldReturnTrue()
    {
        decimal a = 0.1m + 0.2m;
        decimal b = 0.3005m;

        a.DoesNotEqualWithinTolerance(b, 0.0001m).Should().BeTrue();
    }
}
