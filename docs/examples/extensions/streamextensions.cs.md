# System.IO.Stream Extensions

Below are examples of the .NET ``System.IO.Stream`` extension methods in TenjinX.

[Home](../../../README.md)

```c#
using TenjinX.Extensions;

public record Person 
{ 
    public string Name { get; set; } = string.Empty;
    
    public int Age { get; set; } 
}

var jsonObject = new Person { Name: "Alice", Age: 30 };
var jsonString = System.Text.Json.JsonSerializer.Serialize(jsonObject);
var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));

// ReadAsJsonObject<T>
await stream.ReadAsJsonObject<Person>(); // Person { Name = "Alice", Age = 30 }

// Reset stream position for next read
stream.Position = 0;

// ReadAsString
await stream.ReadAsString(); // "{\"Name\": \"Alice\", \"Age\": 30 }"

// Reset stream position for next read
stream.Position = 0;

// ReadAsByteArray
await stream.ReadAsByteArray(); // [123, 34, 78, 97, 109, 101, 34, ...] (UTF-8 bytes)
```
