# System.Collections.Generic.IDictionary<TKey, TValue> Extensions

Below are examples of the .NET ``System.Collections.Generic.IDictionary<TKey, TValue>`` extension methods in TenjinX.

[Home](../../../README.md)

```c#
using TenjinX.Extensions;

// Predefined dictionary
var dict = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

// DoesNotContainKey
dict.DoesNotContainKey("c"); // True
dict.DoesNotContainKey("a"); // False

// TryAdd with Func<TValue>
dict.TryAdd("c", () => 3);  // True (dictionary now contains { "c", 3 })
dict.TryAdd("a", () => 99); // False (key "a" already exists)

// TryAdd with Func<Task<TValue>>
dict.TryAdd("d", async () => await Task.FromResult(4));     // True (dict now contains { "d", 4 })
dict.TryAdd("b", async () => await Task.FromResult(88));    // False (key "b" already exists)
```
