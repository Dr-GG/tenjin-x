# Math extensions

Below are examples of the .NET ``Math extensions`` extension methods in TenjinX.

[Home](../../../README.md)

```c#
using TenjinX.Extensions;

// EqualsWithinTolerance (float)
1.0000001f.EqualsWithinTolerance(1.0000002f);   // True
1.0001f.EqualsWithinTolerance(1.0002f);         // False

// EqualsWithinTolerance (double)
1.000000001.EqualsWithinTolerance(1.000000002); // True
1.0001.EqualsWithinTolerance(1.0002);           // False

// EqualsWithinTolerance (decimal)
1.000000001m.EqualsWithinTolerance(1.000000002m);   // True
1.0001m.EqualsWithinTolerance(1.0002m);             // False

// DoesNotEqualWithinTolerance (float)
1.0001f.DoesNotEqualWithinTolerance(1.0002f);       // True
1.0000001f.DoesNotEqualWithinTolerance(1.0000002f); // False

// DoesNotEqualWithinTolerance (double)
1.0001.DoesNotEqualWithinTolerance(1.0002);             // True
1.000000001.DoesNotEqualWithinTolerance(1.000000002);   // False

// DoesNotEqualWithinTolerance (decimal)
1.0001m.DoesNotEqualWithinTolerance(1.0002m);           // True
1.000000001m.DoesNotEqualWithinTolerance(1.000000002m); // False
```
