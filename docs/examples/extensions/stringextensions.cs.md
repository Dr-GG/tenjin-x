# System.String Extensions

Below are examples of the .NET ``System.String`` extension methods in TenjinX.

[Home](../../../README.md)

```c#
using TenjinX.Extensions;

// IsNullOrEmpty
((string?)null).IsNullOrEmpty();    // True
"Hello".IsNullOrEmpty();            // False

// IsNotNullAndEmpty
((string?)null).IsNotNullAndEmpty();    // True
strNull.IsNotNullAndEmpty();            // False

// IsNullOrWhiteSpace
"   ".IsNullOrWhiteSpace();     // True
"Hello".IsNullOrWhiteSpace();   // False

// IsNotNullAndWhiteSpace
"Hello".IsNotNullAndWhiteSpace();   // True
"   ".IsNotNullAndWhiteSpace();     // False

// IsEmpty
"".IsEmpty();       // True
"Hello".IsEmpty(); // False

// IsNotEmpty
"Hello".IsNotEmpty();   // True
"".IsNotEmpty();        // False

// IsEmptyOrWhiteSpace
"   ".IsEmptyOrWhiteSpace();    // True
"Hello".IsEmptyOrWhiteSpace();  // False

// IsNotEmptyOrWhiteSpace
"Hello".IsNotEmptyOrWhiteSpace();   // True
"   ".IsNotEmptyOrWhiteSpace();     // False

// EqualsOrdinalIgnoreCase
"hello".EqualsOrdinalIgnoreCase("HELLO"); // True
"hello".EqualsOrdinalIgnoreCase("world"); // False
```
