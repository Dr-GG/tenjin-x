using System;
using TenjinX.Interfaces.Providers;

namespace TenjinX.Implementations.Providers;

/// <summary>
/// The implementation of the <see cref="ITenjinSystemClockProvider"/> that uses a UTC system clock.
/// </summary>
public class TenjinUtcSystemClockProvider : ITenjinSystemClockProvider
{
    /// <inheritdoc />
    public DateTime Now()
    {
        return DateTime.UtcNow;
    }
}