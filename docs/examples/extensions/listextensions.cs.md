# System.Collections.Generic.IList<T>

Below are examples of the .NET ``System.Collections.Generic.IList<T>`` extension methods in TenjinX.

[Home](../../../README.md)

```c#
using TenjinX.Extensions;

var list = new List<int> { 1, 3, 5, 7 };

// RemoveRangeAt
list.RemoveRangeAt(1, 3); // [1, 5]

// BinaryInsert
list.BinaryInsert(4);                           // Inserts 4 at index 1 → [1, 4, 5]
list.BinaryInsert(6, (a, b) => a.CompareTo(b)); // Inserts 6 at index 3 → [1, 4, 5, 6]
list.BinaryInsert(2, Comparer<int>.Default);    // Inserts 2 at index 1 → [1, 2, 4, 5, 6]
```
