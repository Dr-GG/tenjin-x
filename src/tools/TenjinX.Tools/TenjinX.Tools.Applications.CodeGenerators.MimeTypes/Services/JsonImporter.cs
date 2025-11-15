using System.Text.Json;
using TenjinX.Tools.Applications.CodeGenerators.MimeTypes.Constants;
using TenjinX.Tools.Applications.CodeGenerators.MimeTypes.Models;

namespace TenjinX.Tools.Applications.CodeGenerators.MimeTypes.Services;

public class JsonImporter
{
    public MimeTypeData Import(string filename)
    {
        var document = GetMimeTypeJsonDocument(filename);
        var fileExtensionToMimeTypes = Parse(document).ToList();

        return new MimeTypeData
        {
            FileExtensionToMimeTypes = fileExtensionToMimeTypes,
            MimeTypeToFileExtensions = GetMimeTypeToFileExtensions(fileExtensionToMimeTypes)
        };
    }

    private static IEnumerable<MimeTypeRecord> GetMimeTypeToFileExtensions(
        IEnumerable<MimeTypeRecord> fileExtensionToMimeTypes)
    {
        return [.. fileExtensionToMimeTypes
            .GroupBy(m => m.MimeType)
            .Select(g => new
            {
                MimeType = g.Key,
                FileExtensions = g
                    .Select(m => m.FileExtension)
                    .ToList(),
                PriorityReference = MimeTypeValues
                    .PrioritisedMimeTypeFileExtensions
                    .SingleOrDefault(p => p.MimeType.Equals(g.Key))
            })
            .Select(d => new MimeTypeRecord
            {
                MimeType = d.MimeType,
                FileExtensions = d.FileExtensions
                    .OrderBy(f => d.PriorityReference?.FileExtension.Equals(f) ?? false
                        ? 0 : 1)
                    .ThenBy(f => f)
            })];
    }

    private static JsonDocument GetMimeTypeJsonDocument(string filename)
    {
        using var stream = File.Open(filename, FileMode.Open, FileAccess.Read);

        return JsonDocument.Parse(stream);
    }

    private static IEnumerable<MimeTypeRecord> Parse(JsonDocument document)
    {
        var enumerator = document.RootElement.EnumerateObject();
        var result = new List<MimeTypeRecord>();

        while (enumerator.MoveNext())
        {
            var value = enumerator.Current.Value.GetString();

            if (string.IsNullOrEmpty(value))
            {
                continue;
            }

            var item = new MimeTypeRecord
            {
                FileExtension = enumerator.Current.Name.ToLower(),
                MimeType = value.ToLower()
            };

            result.Add(item);
        }

        return [.. result.OrderBy(m => m.MimeType)];
    }
}