# System.Threading.CancellationToken Extensions

Below are examples of the .NET ``System.Threading.CancellationToken`` extension methods in TenjinX.

[Home](../../../README.md)

```c#
using TenjinX.Extensions;

var tokenSource = new CancellationTokenSource(); 
var token = tokenSource.Token;

// CanContinue & CannotContinue
token.CanContinue();    // True
token.CannotContinue(); // False

tokenSource.cancel();

// CanContinue & CannotContinue
cts.Token.CanContinue();    // False
cts.Token.CannotContinue(); // True
```
