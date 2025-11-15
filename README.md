| Tenjin | SonarCloud | Badges |
|-|-|-|
|[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Dr-GG_tenjin-x&metric=alert_status)](https://sonarcloud.io/summary/overall?id=Dr-GG_tenjin-x&branch=main)|[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=Dr-GG_tenjin-x&metric=reliability_rating)](https://sonarcloud.io/summary/overall?id=Dr-GG_tenjin-x&branch=main)|[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=Dr-GG_tenjin-x&metric=coverage)](https://sonarcloud.io/summary/overall?id=Dr-GG_tenjin-x&branch=main)|
|[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=Dr-GG_tenjin-x&metric=security_rating)](https://sonarcloud.io/summary/overall?id=Dr-GG_tenjin-x&branch=main)|[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=Dr-GG_tenjin-x&metric=sqale_rating)](https://sonarcloud.io/summary/overall?id=Dr-GG_tenjin-x&branch=main)|[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=Dr-GG_tenjin-x&metric=vulnerabilities)](https://sonarcloud.io/summary/overall?id=Dr-GG_tenjin-x&branch=main)|

# TenjinX - A Collection of Lightweight Utilities & Extensions for .NET

A small, focused collection of helpers, extension methods and lightweight collections that speed common tasks in .NET applications. Designed to be dropped into projects (or consumed via NuGet) to reduce boilerplate and make code intent clearer.

## Why use TenjinX?
- Reduces repetitive checks and boilerplate.
- Small, well-scoped helpers that make intent explicit.
- Mix-and-match: use individual helpers without heavy dependencies.
- Designed for modern .NET (tested on .NET 10).

Compatible with .NET 10.

Below are some quick examples of using TenjinX.

```c#

// String Extensions
// =================

// IsNullOrWhiteSpace
"   ".IsNullOrWhiteSpace();     // True
"Hello".IsNullOrWhiteSpace();   // False

// IsNotNullAndWhiteSpace
"Hello".IsNotNullAndWhiteSpace();   // True
"   ".IsNotNullAndWhiteSpace();     // False

// IsEmpty
"".IsEmpty();       // True
"Hello".IsEmpty(); // False

// IsNotEmpty
"Hello".IsNotEmpty();   // True
"".IsNotEmpty();        // False

// IsEmptyOrWhiteSpace
"   ".IsEmptyOrWhiteSpace();    // True
"Hello".IsEmptyOrWhiteSpace();  // False

// IEnumerable extensions
// ======================

var nums = new[] { 1, 2, 3, 4, 5 };

// EnumerateToList
nums.EnumerateToList(); // List<int>([1, 2, 3, 4, 5])

// IsEmpty & IsNotEmpty
nums.IsEmpty();     // False
nums.IsNotEmpty();  // True

// IsNotNullOrEmpty & IsNullOrEmpty
nums.IsNotNullOrEmpty();                    // True
((IEnumerable<int>?)null).IsNullOrEmpty();  // True

// TenjinMimeTypeUtilities
// =======================

// GetMimeType
TenjinMimeTypeUtilities.GetMimeType(".jpg");        // "image/jpeg"
TenjinMimeTypeUtilities.GetMimeType("png");         // "image/png"
TenjinMimeTypeUtilities.GetMimeType(".unknown");    // null

// GetFileExtension
TenjinMimeTypeUtilities.GetFileExtension("image/jpeg");         // ".jpg"
TenjinMimeTypeUtilities.GetFileExtension("application/pdf");    // ".pdf"
TenjinMimeTypeUtilities.GetFileExtension("unknown/type");       // null

// GetAllFileExtensions
TenjinMimeTypeUtilities.GetAllFileExtensions("image/jpeg");         // [".jpg", ".jpe", ".jpeg"]
TenjinMimeTypeUtilities.GetAllFileExtensions("application/msword"); // [".doc", ".dot", ".wiz"]
TenjinMimeTypeUtilities.GetAllFileExtensions("unknown/type");       // []
```

## TenjinX Examples

* Extensions
  * [System.Collections.Generic.ICollection<T> extensions](/docs/examples/extensions/collectionextensions.cs.md)
  * [System.Collections.Generic.IDictionary<TKey, TValue> extensions](/docs/examples/extensions/dictionaryextensionds.cs.md)
  * [System.Collections.Generic.IEnumerable<T> extensions](/docs/examples/extensions/enumerableextensions.cs.md)
  * [System.Collections.Generic.IList<T> extensions](/docs/examples/extensions/listextensions.cs.md)  
  * [System.DateOnly extensions](/docs/examples/extensions/dateonlyextensions.cs.md)  
  * [System.DateTime extensions](/docs/examples/extensions/datetimeextensions.cs.md)
  * [System.Enum extensions](/docs/examples/extensions/enumextensions.cs.md)
  * [System.IO.Stream extensions](/docs/examples/extensions/streamextensions.cs.md)  
  * [System.Object extensions](/docs/examples/extensions/objectsextensions.cs.md)
  * [System.String extensions](/docs/examples/extensions/stringextensions.cs.md)
  * [System.Threading.CancellationToken extensions](/docs/examples/extensions/cancellationtokenextensions.cs.md)  
  * [System.Type extensions](/docs/examples/extensions/typextensions.cs.md)
  * [Math extensions extensions](/docs/examples/extensions/listextensions.cs.md)
* Implementations
  * Collections
    * [TenjinHashCodeDictionary](/docs/examples/./implementations/collections/tenjinhashcodedictionary.cs.md)
  * Comparers
    * [TenjinComparer](/docs/examples/./implementations/comparers/tenjinfunctioncomparer.cs.md)
* Utilities
  * [TenjinMimeTypeUtilities](/docs/examples/utilities/tenjinmimetypeutilities.cs.md)
  * [TenjinRandomGenerationUtilities](/docs/examples/utilities/tenjinrandomgenerationutilities.cs.md)
  
