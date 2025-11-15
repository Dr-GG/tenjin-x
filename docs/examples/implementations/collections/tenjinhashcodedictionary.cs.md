# TenjinX.Implementations.Collections.TenjinHashCodeDictionary

Below are examples of the ``TenjinX.Implementations.Collections.TenjinHashCodeDictionary``.

[Home](../../../../README.md)

```c#
using TenjinX.Implementations.Collections;

/*
 * The TenjinHashCodeDictionary uses the hash code of an object to store itself.
 */

// Example class.
public record Person 
{ 
    public string Name { get; set; } = string.Empty;
}

var dictionary = new TenjinHashCodeDictionary<Person>();
var alice = new Person { Name = "Alice" };  // Assume it produces hash code 1
var bob = new Person { Name = "Bob" };      // Assume it produces hash code 2

dictionary.Add(alice);  // Dictionary is now [{ 1: alice }]
dictionary.Add(bob);    // Dictionary is now [{ 1: alice }, { 2: bob }]

// Access by object
var person = dictionary[alice]; // Returns Alice

// Check existence
dictionary.Contains(alice);                                 // True
dictionary.DoesNotContain(new Person { Name = "Charlie" }); // True

// Remove by object
dictionary.Remove(bob);

// TryAdd prevents duplicates based on hash code
var added = dictionary.TryAdd(alice); // False (already exists)

// Copy to another TenjinHashCodeDictionary
var anotherDictionary = new TenjinHashCodeDictionary<Person>();

dictionary.CopyTo(anotherDictionary);

Console.WriteLine($"Count: {dictionary.Count}"); // Count: 1
```
