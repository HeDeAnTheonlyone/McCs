using McCs.Utils;
using Octokit;
using Newtonsoft.Json;

namespace McCs;

public class Datapack
{
   /// <summary>
   /// If left empty, the pack will be saved in your documents folder.
   /// </summary>
   public static string? packSavePath;
   public readonly string Name;
   private int maxFormat = 0;
   private const int minFormat = 4;
   private int[] packFormat;
   private int[] PackFormat
   {
      get => packFormat;
      set
      {
         packFormat = new int[Math.Clamp(value.Length, 1, 2)];
         int index = 0;

         foreach (int num in value)
         {
            if (num < minFormat && num > maxFormat && num != -1)
               throw new ArgumentException("PackFormat is not a valid number", nameof(value));
            else if (num == -1)
               packFormat[index] = maxFormat;
            else
               packFormat[index] = num;

            index++;

            if (index == 2)
               break;
         }
      }
   }
   private string Description { get; } = "";
   private PackFilter Filter { get; }
   private PackOverlays Overlays { get; }
   public List<Function> Functions { get; } = new List<Function>();


   /// <summary>
   /// <para>
   /// If a pack format is set to -1 it will get the newest one automatically.
   /// </para>
   /// </summary>
   public Datapack(string name, int[] packFormat)
   {
      Name = name;

      if (packFormat.Contains(-1))
         GetPackFormat().Wait();

      PackFormat = packFormat;
   }
   public Datapack(string name, int[] packFormat, PackFilter filter) : this(name, packFormat)
   {
      Filter = filter;
   }
   public Datapack(string name, int[] packFormat, PackOverlays overlays) : this(name, packFormat)
   {
      Overlays = overlays;
   }
   public Datapack(string name, int[] packFormat, PackFilter filter, PackOverlays overlays) : this(name, packFormat, filter)
   {
      Overlays = overlays;
   }



#region Packformat from GitHub
   private async Task GetPackFormat()
   {
      const string owner = "misode";
      const string repo = "mcmeta";
      const string filePath = "version.json";
      const string branch = "data-json";

      //TODO Add GitHub OAuth for API call limits 

      GitHubClient github = new GitHubClient(new ProductHeaderValue("AngDem"));

      try
      {
         var contents = await github.Repository.Content.GetAllContentsByRef(owner, repo, filePath, branch);
         if (contents.Count > 0)
         {
            string versionJson = contents[0].Content;
            Dictionary<string, object> versionMetaData = JsonConvert.DeserializeObject<Dictionary<string, object>>(versionJson);

            if (versionMetaData["data_pack_version"] != null)
               maxFormat = (int)(long)versionMetaData["data_pack_version"];
            else
               PackFormatError("Couldn't apply pack format. Fallback to version 26.");
         }
         else
         {
            PackFormatError("Couldn't load version metadata. Fallback to version 26.");
         }
      }
      catch
      {
         PackFormatError("Error whilest trying to fetch most recent metadata. Fallback to version 26.");
      }
   }



   private void PackFormatError(string errMessage)
   {
      PackFormat = [26];
      throw new Exception(errMessage);
   }
#endregion



#region Pack Compiler
   public void Compile()
   {
      DirectoryInfo packDir;
      
      packSavePath = string.Join("/", packSavePath, Name);
      string? newSavePath = string.Join("/", FileManagement.CheckSavePath(packSavePath), Name);

      if (newSavePath != null)
         packSavePath = newSavePath;

      if (Directory.Exists(packSavePath))
         packDir = new DirectoryInfo(packSavePath);
      else
         packDir = Directory.CreateDirectory(packSavePath);

      CreatMcMetaFile(packDir);
   }



   private void CreatMcMetaFile(DirectoryInfo folderPath)
   {
      string filepath = $"{folderPath.FullName}/pack.mcmeta";

      string jsonData = BuildMcMetaData();

      using(var file = File.CreateText(filepath))
      {
         file.WriteLine(jsonData);
      }
   }



   private string BuildMcMetaData()
   {
      Dictionary<string, object> packMcMeta = new Dictionary<string, object>();
      Dictionary<string, object> pack = new Dictionary<string, object>()
      {
         { "Description", Description },
         { "pack_format", PackFormat[0] }
      };
      if (PackFormat.Length >= 2)
         pack.Add("supported_formats", packFormat);
         
      packMcMeta.Add("pack", pack);

      if (Filter != null)
         packMcMeta.Add("filter", Filter.filter);

      if (false/*Overlays != null*/) //TODO Add PackOverlay support 
         packMcMeta.Add("overlays", Overlays);

      return JsonConvert.SerializeObject(packMcMeta, Formatting.Indented);
   }
#endregion
}