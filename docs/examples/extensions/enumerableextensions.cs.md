# System.Collections.Generic.IEnumerable<T>

Below are examples of the .NET ``System.Collections.Generic.IEnumerable<T>`` extension methods in TenjinX.

[Home](../../../README.md)

```c#
using TenjinX.Extensions;

var nums = new[] { 1, 2, 3, 4, 5 };

// EnumerateToList
nums.EnumerateToList(); // List<int>([1, 2, 3, 4, 5])

// IsEmpty & IsNotEmpty
nums.IsEmpty();     // False
nums.IsNotEmpty();  // True

// IsNotNullOrEmpty & IsNullOrEmpty
nums.IsNotNullOrEmpty();                    // True
((IEnumerable<int>?)null).IsNullOrEmpty();  // True

// LastIndexOf 
nums.LastIndexOf(3);                // 2
nums.LastIndexOf(x => x % 2 == 0);  // 3

// IndexOf
nums.IndexOf(x => x > 3); // 3

// LastIndex
nums.LastIndex(); // 4

// ToJoinedString
nums.ToJoinedString(", "); // "1, 2, 3, 4, 5"

// PartitionInto
nums.PartitionInto(1);  // [1, 2, 3, 4, 5]
nums.PartitionInto(2);  // [[1, 2], [3, 4, 5]]
nums.PartitionInto(3);  // [[1, 2], [3, 4], [5]]
nums.PartitionInto(10); // [[1], [2], [3], [4], [5]]

// Contains (predicate)
nums.Contains(x => x == 3); // True

// ContainsAll
nums.ContainsAll(new[] { 1, 2 });   // True
nums.ContainsAll(x => x > 0);       // True

// ContainsAny (items)
nums.ContainsAny(new[] { 10, 2 });  // True
nums.ContainsAny(x => x > 4);       // True

// DoesNotContain (item)
nums.DoesNotContain(10);            // True
nums.DoesNotContain(x => x < 0);    // True

// DoesNotContainAny
nums.DoesNotContainAny(new[] { 10, 11 });   // True
nums.DoesNotContainAny(x => x < 0);         // True

// DoesNotContainAll
nums.DoesNotContainAll(new[] { 1, 10 });    // True
nums.DoesNotContainAll(x => x > 10);        // True

// ForEach
nums.ForEach(x => Console.Write(x));                            // Writes: 12345
nums.ForEach((i, x) => Console.Write($"[{i}]={x}"));            // Writes: [0]=1[1]=2...
nums.ForEach((ctx, x) => Console.Write($"{ctx.Index}:{x}"));    // Writes: 0:1 1:2 ...

// BinarySearch
nums.BinarySearch(3, (a, b) => a.CompareTo(b));     // 2
nums.BinarySearch(4, Comparer<int>.Default);        // 3

// BinarySearchContains
nums.BinarySearchContains(3);                               // True
nums.BinarySearchContains(6, (a, b) => a.CompareTo(b));     // False
nums.BinarySearchContains(5, Comparer<int>.Default);        // True

// GetCollectionHashCode
nums.GetCollectionHashCode(); // e.g., 123456789 (varies)
```
