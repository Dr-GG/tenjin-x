# TenjinX.Implementations.Comparers.TenjinFunctionComparer

Below are examples of the ``TenjinX.Implementations.Comparers.TenjinFunctionComparer``.

[Home](../../../../README.md)

```c#
using TenjinX.Implementations.Comparers;

/*
 * The TenjinComparer is a wrapper class for IComparer and IComparer<TValue> using a lambda function.
 */

// Create a custom comparer using a lambda function
var comparer = new TenjinFunctionComparer<int>((x, y) => x.CompareTo(y));
var numbers = new List<int> { 5, 1, 3 };

// Use it in a sorted list
numbers.Sort(comparer); // Sorted list is no [1, 3, 5]

comparer.Compare(10, 20); // -1 (10 < 20)
comparer.Compare(20, 10); //  1 (20 > 20)
comparer.Compare(10, 10); //  0 (10 == 20)
```
