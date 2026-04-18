using TenjinX.Constants;
using TenjinX.Enums;
using TenjinX.Exceptions;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of extension methods for hashing operations within the TenjinX library.
/// </summary>
/// <remarks>
/// The .NET libraries no longer support deterministic hashing for objects, which is why this extension method is necessary. 
/// These extension methods provide deterministic hashing functionality for various objects.
/// The following types are supported in this class and their underlying hashing algorithms:
/// <list type="bullet">
///     <term><see cref="string"/></term>
///     <description>
///         Uses the provided <see cref="TenjinXHashingAlgorithm"/> to compute a deterministic hash code for the string.
///     </description>
///     <term>C# struct based (value) types</term>
///     <description>
///         For struct based (value) types, the default .NET hashing algorithm is used, which is deterministic for value types.
///         Even though the default .NET hashing algorithm is deterministic for value types, the same method can be used
///         to support potential .NET updates that may change the hashing algorithm for value types in the future, 
///         ensuring that the hashing remains deterministic regardless of .NET updates. 
///         These hashing algorithms do not require a specified hashing algorithm.
///     </description>
/// </list>
/// </remarks>
public static class HashingExtensions
{
    /// <summary>
    /// Hashes a <see cref="string"/> to a deterministic hash code using the specified hashing algorithm.
    /// </summary>
    public static int GetDeterministicHashCode(this string? value, TenjinXHashingAlgorithm algorithm = TenjinXHashingAlgorithm.Fnv1A32Bit)
    {
        if (value.IsNullOrEmpty())
        {
            return 0;
        }

        if (algorithm == TenjinXHashingAlgorithm.Fnv1A32Bit)
        {
            return GetFNV1A32BitHashCode(value);
        }

        throw new TenjinException($"Unsupported hashing algorithm: {algorithm}");
    }

    /// <summary>
    /// Hashes a struct based (value) type to a deterministic hash code using the default .NET hashing algorithm, which is deterministic for value types.
    /// </summary>
    public static int GetDeterministicHashCode<T>(this T? value) where T : struct
    {
        return value?.GetHashCode() ?? 0;
    }

    /// <summary>
    /// Hashes a string using the FNV-1a 32-bit algorithm.
    /// </summary>
    private static int GetFNV1A32BitHashCode(string value)
    {
        var hash = TenjinxXHashingValues.Fnv.OneA.Int32.OffsetBasis;

        for (var i = 0; i < value.Length; i++)
        {
            hash ^= value[i];
            hash *= TenjinxXHashingValues.Fnv.OneA.Int32.Prime;
        }

        return (int)hash;
    }
}
