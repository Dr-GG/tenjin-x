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
    /// <remarks>
    /// This method does not dispose the parameter <paramref name="stream"/>. 
    /// The caller is responsible for disposing it.
    /// </remarks>
    public static async Task<T?> ReadAsJsonObject<T>
    (
        this Stream stream,
        JsonSerializerOptions? jsonOptions = null
    ) where T : class
    {
        using var reader = new StreamReader(stream, leaveOpen: true);

        var json = await reader.ReadToEndAsync().ConfigureAwait(false);

        if (json.IsEmpty())
        {
            return null;
        }

        return JsonSerializer.Deserialize<T>(json, jsonOptions);
    }

    /// <summary>
    /// Reads the stream and returns its content as a string.
    /// </summary>
    /// <remarks>
    /// The caller is responsible for disposing the parameter <paramref name="stream"/>.
    /// </remarks>
    public static async Task<string> ReadAsString(this Stream stream)
    {
        using var reader = new StreamReader(stream, leaveOpen: true);

        return await reader.ReadToEndAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Reads the stream and returns its content as a byte <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <remarks>
    /// The caller is responsible for disposing the parameter <paramref name="stream"/>.
    /// </remarks>
    public static async Task<IEnumerable<byte>> ReadAsByteEnumerable(this Stream stream)
    {
        using var memoryStream = new MemoryStream();

        await stream.CopyToAsync(memoryStream).ConfigureAwait(false);

        return memoryStream.ToArray();
    }
}
