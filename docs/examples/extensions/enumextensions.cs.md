# System.Enum Extensions

Below are examples of the .NET ``System.Enum`` extension methods in TenjinX.

[Home](../../../README.md)

```c#
using TenjinX.Extensions;

enum Permissions
{
    None = 0,
    Read = 1,
    Write = 2,
    Execute = 4
}

var permissions = Permissions.Read | Permissions.Write | Permissions.Execute;

// GetFlags
permissions.GetFlags(); // [Permissions.Read, Permissions.Write, Permissions.Execute]

// MergeFlags
(new[] { Permissions.Read, Permissions.Write }).MergeFlags(); // Read | Write

// ParseAsEnum
"Write".ParseAsEnum<Permissions>(); // Write

// ParseAsNullableEnum
"Execute".ParseAsNullableEnum<Permissions>();                   // Execute
"Invalid".ParseAsNullableEnum<Permissions>(Permissions.None);   // None

// TryParseAsEnum
"Read".TryParseAsEnum<Permissions>(out var parsed);             // True (parsed = Read)
"Invalid".TryParseAsEnum<Permissions>(out var invalidParsed);   // False (invalidParsed = None)
```
