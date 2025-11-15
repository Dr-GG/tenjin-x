namespace TenjinX.Extensions;

/// <summary>
/// A collection of extension methods for the Object class.
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Determines if two object instances do not equal one another.
    /// </summary>
    public static bool DoesNotEqual<TObject>(this TObject? left, TObject? right)
    {
        return !Equals(left, right);
    }
}