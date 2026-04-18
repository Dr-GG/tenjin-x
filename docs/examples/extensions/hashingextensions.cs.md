# Hashing Extensions

## Reason for the hashing extensions

The .NET libraries no longer support deterministic hashing for objects, which is why this extension method is necessary. 
These extension methods provide deterministic hashing functionality for various objects.
The following types are supported in this class and their underlying hashing algorithms:

* ***System.String***: Uses the provided ``TenjinXHashingAlgorithm`` to compute a deterministic hash code for the string.
* ***C# Struct/Value types***: For struct based (value) types, the default .NET hashing algorithm is used, which is deterministic forv alue types. Even though the default .NET hashing algorithm is deterministic for value types, the same method can be used to support potential .NET updates that may change the hashing algorithm for value types in the future, ensuring that the hashing remains deterministic regardless of .NET updates. These hashing algorithms do not require a specified hashing algorithm.

The TenjinX library supports the following hashing algorithms for ``System.String`` based values:

* ***Fowler-Noll-Vo (FNV) 1a 32-bit***: A non-cryptographic hash function known for its speed and simplicity.

Below are examples of the .NET Hashing extension methods in TenjinX.

[Home](../../../README.md)

```c#
using TenjinX.Extensions;

// String values.
"hello".GetDeterministicHashCode();         // 1335831723
"world".GetDeterministicHashCode();         // 933488787
"".GetDeterministicHashCode();              // 0
((string?)null).GetDeterministicHashCode(); // 0

// Struct or type based values.
var integerValue = 1;
var booleanValue = true;
var dateTimeValue = DateTime.Now;

integerValue.GetDeterministicHashCode();        // 1
booleanValue.GetDeterministicHashCode();        // 1
dateTimeValue.GetDeterministicHashCode();       // Determined at run-time.
```
