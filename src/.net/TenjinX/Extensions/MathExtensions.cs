using System;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of math based extensions.
/// </summary>
public static class MathExtensions
{
    /// <summary>
    /// The <see cref="float"/> tolerance level or constant to be used between two <see cref="float"/> instances.
    /// </summary>
    public const float SingleTolerance = 0.0000001f;

    /// <summary>
    /// The <see cref="double"/> tolerance level or constant to be used between two <see cref="double"/> instances.
    /// </summary>
    public const double DoubleTolerance = 0.000000001;

    /// <summary>
    /// The <see cref="decimal"/> tolerance level or constant to be used between two <see cref="decimal"/> instances.
    /// </summary>
    public const decimal DecimalTolerance = 0.000000001m;

    /// <summary>
    /// Determines if two <see cref="float"/> instances are equal to one another using a tolerance level.
    /// </summary>
    public static bool EqualsWithinTolerance(this float left, float right, float tolerance = SingleTolerance)
    {
        return Math.Abs(left - right) < tolerance;
    }

    /// <summary>
    /// Determines if two <see cref="double"/> instances are equal to one another using a tolerance level.
    /// </summary>
    public static bool EqualsWithinTolerance(this double left, double right, double tolerance = DoubleTolerance)
    {
        return Math.Abs(left - right) < tolerance;
    }

    /// <summary>
    /// Determines if two <see cref="decimal"/> instances are equal to one another using a tolerance level.
    /// </summary>
    public static bool EqualsWithinTolerance(this decimal left, decimal right, decimal tolerance = DecimalTolerance)
    {
        return Math.Abs(left - right) < tolerance;
    }

    /// <summary>
    /// Determines if two <see cref="float"/> instances are not equal to one another using a tolerance level.
    /// </summary>
    public static bool DoesNotEqualWithinTolerance(this float left, float right, float tolerance = SingleTolerance)
    {
        return !left.EqualsWithinTolerance(right, tolerance);
    }

    /// <summary>
    /// Determines if two <see cref="double"/> instances are not equal to one another using a tolerance level.
    /// </summary>
    public static bool DoesNotEqualWithinTolerance(this double left, double right, double tolerance = DoubleTolerance)
    {
        return !left.EqualsWithinTolerance(right, tolerance);
    }

    /// <summary>
    /// Determines if two <see cref="decimal"/> instances are not equal to one another using a tolerance level.
    /// </summary>
    public static bool DoesNotEqualWithinTolerance(this decimal left, decimal right, decimal tolerance = DecimalTolerance)
    {
        return !left.EqualsWithinTolerance(right, tolerance);
    }
}