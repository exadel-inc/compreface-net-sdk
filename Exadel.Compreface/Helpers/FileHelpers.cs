namespace Exadel.Compreface.Helpers;

public class FileHelpers
{
    public static string GenerateFileName(string filePath)
    {
        //if (!File.Exists(filePath))
        //{
        //    throw new FileNotFoundException(message: $"file does not exist in path : {filePath}!!!");
        //}

        var fileExtension = Path.GetExtension(filePath);

        var generatedFileName = $"{Guid.NewGuid()}{fileExtension}";

        return generatedFileName;
    }
}