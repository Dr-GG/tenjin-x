using System;

namespace TenjinX.Interfaces.Providers;

/// <summary>
/// An interface that provides a DateTime instance.
/// </summary>
public interface ITenjinSystemClockProvider
{
    /// <summary>
    /// Gets the current DateTime instance.
    /// </summary>
    DateTime Now();
}