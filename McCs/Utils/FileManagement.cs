
namespace McCs.Utils;

public static class FileManagement
{
   public static string CheckSavePath(string? dirPath)
   {
      if (dirPath == null || !Directory.Exists(dirPath))
         return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

      return null;
   }
}