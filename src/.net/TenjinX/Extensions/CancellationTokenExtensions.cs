using System.Threading;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of extension methods for CancellationToken instances.
/// </summary>
public static class CancellationTokenExtensions
{
    /// <summary>
    /// Determines if a CancellationToken can continue.
    /// </summary>
    public static bool CanContinue(this CancellationToken cancellationToken)
    {
        return !cancellationToken.IsCancellationRequested;
    }

    /// <summary>
    /// Determines if a CancellationToken cannot continue.
    /// </summary>
    public static bool CannotContinue(this CancellationToken cancellationToken)
    {
        return cancellationToken.IsCancellationRequested;
    }
}