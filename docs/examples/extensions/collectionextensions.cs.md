# System.Collections.Generic.ICollection<T> Extensions

Below are examples of the .NET ``System.Collections.Generic.ICollection<T>`` extension methods in TenjinX.

[Home](../../../README.md)

```c#
using TenjinX.Extensions;

var list = new List<int>();

// Using AddRange
list.AddRange(1, 2, 3, 4); // [1, 2, 3, 4]

// Using RemoveRange
list.RemoveRange(2, 4); // [1, 3]
```
