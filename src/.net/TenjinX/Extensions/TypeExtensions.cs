using System;
using TenjinX.Exceptions;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of extension methods for the <see cref="Type"/> class.
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    /// Gets the full name of a <see cref="Type"/>.
    /// </summary>
    /// <exception cref="TenjinException">
    /// Thrown if <paramref name="type"/> does not have a full name.
    /// </exception>
    public static string GetFullName(this Type type)
    {
        var fullName = type.FullName;

        if (fullName.IsNullOrEmpty())
        {
            throw new TenjinException($"The type '{type.Name}' does not have a full name.");
        }

        return fullName;
    }
}
