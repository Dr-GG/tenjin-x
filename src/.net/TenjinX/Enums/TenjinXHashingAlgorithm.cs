using TenjinX.Constants;

namespace TenjinX.Enums;

/// <summary>
/// Defines the hashing algorithms that can be used for hashing operations within the TenjinX library.
/// </summary>
public enum TenjinXHashingAlgorithm
{
    /// <summary>
    /// The Fowler-Noll-Vo (FNV) 1a 32-bit hashing algorithm, a non-cryptographic hash function known for its speed and simplicity.
    /// </summary>
    /// <remarks>
    /// This hashing algorithm uses the following offsets:
    /// <list type="bullet">
    ///     <item>
    ///         <term>Offset basis:</term>
    ///         <description><see cref="TenjinxXHashingValues.Fnv.OneA.Int32.OffsetBasis"/></description>
    ///     </item>
    ///     <item>
    ///         <term>Prime:</term>
    ///         <description><see cref="TenjinxXHashingValues.Fnv.OneA.Int32.Prime"/></description>
    ///     </item>
    /// </list>
    /// </remarks>
    Fnv1A32Bit
}
