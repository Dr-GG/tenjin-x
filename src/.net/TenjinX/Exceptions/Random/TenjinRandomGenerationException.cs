using System;
using System.Diagnostics.CodeAnalysis;

namespace TenjinX.Exceptions.Random;

/// <summary>
/// The exception class that is generated during the random generation of values.
/// </summary>
[ExcludeFromCodeCoverage]
public class TenjinRandomGenerationException : TenjinException
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    public TenjinRandomGenerationException()
    { }

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    public TenjinRandomGenerationException(string message) : base(message)
    { }

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    public TenjinRandomGenerationException(string message, Exception internalException) : base(message, internalException)
    { }
}