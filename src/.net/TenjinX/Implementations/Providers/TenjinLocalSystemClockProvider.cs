using System;
using TenjinX.Interfaces.Providers;

namespace TenjinX.Implementations.Providers;

/// <summary>
/// The implementation of the <see cref="ITenjinSystemClockProvider"/> that uses the local system clock.
/// </summary>
public class TenjinLocalSystemClockProvider : ITenjinSystemClockProvider
{
    /// <inheritdoc />
    public DateTime Now()
    {
        return DateTime.Now;
    }
}