using TenjinX.Tools.Applications.CodeGenerators.MimeTypes.Constants;
using TenjinX.Tools.Applications.CodeGenerators.MimeTypes.Services;

namespace TenjinX.Tools.Applications.CodeGenerators.MimeTypes;

public static class Program
{
    public static void Main()
    {
        ImportData();

        Console.WriteLine("Done.");
    }

    private static void ImportData()
    {
        Console.Write("Importing data...");

        var importer = new JsonImporter();
        var data = importer.Import(JsonFilenames.JsonInputFilename);

        MimeTypeUtilitiesCodeBuilder.Build(data).GetAwaiter().GetResult();

        Console.WriteLine("DONE!");
        Console.WriteLine();
    }
}