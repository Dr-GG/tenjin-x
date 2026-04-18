namespace TenjinX.Constants;

/// <summary>
/// A collection of constant values used in hashing operations within the TenjinX library.
/// </summary>
public static class TenjinxXHashingValues
{
    /// <summary>
    /// The Fowler-Noll-Vo (FNV) hashing algorithm, a non-cryptographic hash function known for its speed and simplicity.
    /// </summary>
    public static class Fnv
    {
        /// <summary>
        /// The FNV-1a hashing algorithm, a non-cryptographic hash function known for its speed and simplicity.
        /// </summary>
        public static class OneA
        {
            /// <summary>
            /// The 32-bit signed integer values used in the FNV-1a hashing algorithm.
            /// </summary>
            public static class Int32
            {
                /// <summary>
                /// The offset basis for the FNV-1a 32-bit hashing algorithm, used as the initial value for the hash computation.
                /// </summary>
                public const uint OffsetBasis = 2166136261;

                /// <summary>
                /// The prime number used in the FNV-1a 32-bit hashing algorithm.
                /// </summary>
                public const uint Prime = 16777619;
            }
        }
    }
}
