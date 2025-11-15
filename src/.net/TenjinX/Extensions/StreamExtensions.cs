using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace TenjinX.Extensions;

/// <summary>
/// A collection of extension methods for the <see cref="Stream"/> class.
/// </summary>
public static class StreamExtensions
{
    /// <summary>
    /// Reads the stream and deserializes its JSON content into an object of type <typeparamref name="T"/>.
    /// </summary>
    public static async Task<T?> ReadAsJsonObject<T>
    (
        this Stream stream,
        JsonSerializerOptions? jsonOptions = null
    ) where T : class
    {
        using var reader = new StreamReader(stream);

        var json = await reader.ReadToEndAsync();

        if (json.IsEmpty())
        {
            return null;
        }

        return JsonSerializer.Deserialize<T>(json, jsonOptions);
    }

    /// <summary>
    /// Reads the stream and returns its content as a string.
    /// </summary>
    public static async Task<string> ReadAsString(this Stream stream)
    {
        using var reader = new StreamReader(stream);

        return await reader.ReadToEndAsync();
    }

    /// <summary>
    /// Reads the stream and returns its content as a byte array.
    /// </summary>
    public static async Task<IEnumerable<byte>> ReadAsByteArray(this Stream stream)
    {
        using var memoryStream = new MemoryStream();

        await stream.CopyToAsync(memoryStream);

        return memoryStream.ToArray();
    }
}
