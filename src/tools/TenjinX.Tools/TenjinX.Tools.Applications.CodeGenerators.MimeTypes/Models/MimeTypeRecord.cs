namespace TenjinX.Tools.Applications.CodeGenerators.MimeTypes.Models;

public record MimeTypeRecord
{
    public MimeTypeRecord()
    { }

    public MimeTypeRecord(string mimeType, string fileExtension)
    {
        MimeType = mimeType;
        FileExtension = fileExtension;
    }

    public string MimeType { get; init; } = string.Empty;
    public string FileExtension { get; init; } = string.Empty;
    public IEnumerable<string> FileExtensions { get; init; } = [];
}