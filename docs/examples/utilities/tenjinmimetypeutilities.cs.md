# TenjinX.Utilities.TenjinMimeTypeUtilities

Below are examples of using the ``TenjinX.Utilities.TenjinMimeTypeUtilities``.

[Home](../../../README.md)

```c#
using TenjinX.Utilities;

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
