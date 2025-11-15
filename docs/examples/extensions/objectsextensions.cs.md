# System.Object Extensions

Below are examples of the .NET ``System.Object`` extension methods in TenjinX.

[Home](../../../README.md)

```c#
using TenjinX.Extensions;

// DoesNotEqual
"Hello".DoesNotEqual("World");          // True
"Hello".DoesNotEqual("Hello");          // False
((string?)null).DoesNotEqual("Hello");  // True
```
