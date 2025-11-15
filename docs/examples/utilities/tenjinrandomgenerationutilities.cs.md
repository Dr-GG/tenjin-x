# TenjinX.Utilities.TenjinRandomGenerationUtilities

Below are examples of using the ``TenjinX.Utilities.TenjinRandomGenerationUtilities``.

[Home](../../../README.md)

```c#
using TenjinX.Utilities;

// Define parameters
var parametersInt = new TenjinRandomGenerationParameters
{
    MinimumInt32 = 10,  // If null, defaults to int.MinValue
    MaximumInt32 = 20   // If null, default to int.MaxValue - 1
};

var parametersDouble = new TenjinRandomGenerationParameters
{
    MinimumDouble = 0.5,    // If null, defaults to 0
    MaximumDouble = 1.5     // If null, defaults to 1.0.
};

var parametersString = new TenjinRandomGenerationParameters
{
    AllowedCharacters = "ABC123",   // Cannot be null.
    MinimumLength = 5,              // Can be null, if the property Length is set.
    MaximumLength = 10              // Can be null, if the property Length is set.
};

// GetRandomInt32
TenjinRandomGenerationUtilities.GetRandomInt32(parametersInt);      // e.g., 14

// GetRandomDouble
TenjinRandomGenerationUtilities.GetRandomDouble(parametersDouble);  // e.g., 1.23

// GetRandomString
TenjinRandomGenerationUtilities.GetRandomString(parametersString);  // e.g., "A1C23"
```
