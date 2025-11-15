# System.DateTime Extensions

Below are examples of the .NET ``System.DateTime`` extension methods in TenjinX.

[Home](../../../README.md)

```c#
using TenjinX.Extensions;

var dateTimeValue = new DateTime(2025, 11, 20, 14, 30, 0);

// ToDateOnly
dateTimeValue.ToDateOnly();         // 11/20/2025
((DateTime?)null).ToDateOnly();     // null

// ToTimeOnly
dateTimeValue.ToTimeOnly();         // 14:30:00
((DateTime?)null).ToTimeOnly();     // null

// ToDateAndTimeOnly
dateTimeValue.ToDateAndTimeOnly(out var dateOnly, out var timeOnly);                        // dateOnly = 11/20/2025, timeOnly = 14:30:00
((DateTime?)null).ToDateAndTimeOnly(out var nullableDateOnly, out var nullableTimeOnly);    // nullableDateOnly = null, nullableTimeOnly = null
```
