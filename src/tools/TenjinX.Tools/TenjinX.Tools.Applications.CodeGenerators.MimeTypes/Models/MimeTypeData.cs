namespace TenjinX.Tools.Applications.CodeGenerators.MimeTypes.Models;

public record MimeTypeData
{
    public IEnumerable<MimeTypeRecord> FileExtensionToMimeTypes { get; init; } = [];
    public IEnumerable<MimeTypeRecord> MimeTypeToFileExtensions { get; init; } = [];
}