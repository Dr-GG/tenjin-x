# System.DateOnly Extensions

Below are examples of the .NET ``System.DateOnly`` extension methods in TenjinX.

[Home](../../../README.md)

```c#
using TenjinX.Extensions;

var dateOnly = dateOnly;

// Using ToDateTime (DateOnly)
dateOnly.ToDateTime();                      // 2025/11/20 00:00:00 (Unspecified)
dateOnly.ToDateTime(new TimeOnly(14, 30));  // 2025/11/20 14:30:00 (Unspecified)
((DateOnly?)null).ToDateTime();             // null

// Using ToLocalDateTime
dateOnly.ToLocalDateTime();                     // 2025/11/20 00:00:00 (Local)
dateOnly.ToLocalDateTime(new TimeOnly(14, 30)); // 2025/11/20 14:30:00 (Local)
((DateOnly?)null).ToLocalDateTime();            // 11/20/2025 08:15:00 (Local)

// Using ToUtcDateTime
dateOnly.ToUtcDateTime();                       // 2025/11/20 00:00:00 (UTC)
dateOnly.ToUtcDateTime(new TimeOnly(14, 30));   // 2025/11/20 14:30:00 (UTC)
((DateOnly?)null).ToUtcDateTime();              // null
```
