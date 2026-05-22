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
"Hello".IsNotNullAndEmpty();            // False

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
"Hello".IsNotEmptyAndWhiteSpace();   // True
"   ".IsNotEmptyAndWhiteSpace();     // False

// EqualsOrdinalIgnoreCase
"hello".EqualsOrdinalIgnoreCase("HELLO"); // True
"hello".EqualsOrdinalIgnoreCase("world"); // False

"1".ParseAsInt32();                     // 1
((string?)null).ParseAsNullableInt32();    // null

"123".TryParseAsInt32(out var result1);       // Callback: true;  result1: 123
"invalid".TryParseAsInt32(out var result2);   // Callback: false; result2: 0

"123".TryParseAsNullableInt32(out var result3);             // Callback: true;  result3: 123
"invalid".TryParseAsNullableInt32(out var result4);         // Callback: false; result4: null
((string?)null).TryParseAsNullableInt32(out var result5);   // Callback: false; result5: null

"123".TryFailParseAsNullableInt32(out var result6);             // Callback: false;  result3: 123
"invalid".TryFailParseAsNullableInt32(out var result7);         // Callback: true; result4: null
((string?)null).TryFailParseAsNullableInt32(out var result8);   // Callback: true; result5: null

/*
 * TenjinX also supports the following patterns:
 *
 * - ParseAsX
 * - ParseAsNullableX
 * - TryParseAsX
 * - TryParseAsNullableX
 * - TryFailParseAsX
 * - TryFailParseAsNullableX
 *
 * for the following data types in .NET with the keyword in the method names.
 *
 * - bool       / Boolean   / normal .NET boolean.
 * - byte       / Byte      / unsigned 8-bit integer.
 * - sbyte      / SByte     / signed-byte
 * - ushort     / UInt16    / unsigned 16-bit integer.
 * - uint       / UInt32    / unsigned 32-bit integer.
 * - ulong      / UInt64    / unsigned 64-bit integer.
 * - short      / Int16     / signed 16-bit integer.
 * - int        / Int32     / signed 32-bit integer.
 * - long       / Int64     / signed 64-bit integer.
 * - double     / Double    / normal .NET double.
 * - float      / Float     / normal .NET float/single.
 * - decimal    / Decimal   / normal .NET decimal.
 * - Guid       / Guid      / normal .NET GUID.
 * - Enums      / Enum      / Any enum value.
 */

```
