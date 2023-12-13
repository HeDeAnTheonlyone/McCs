using Newtonsoft.Json;
using Octokit;

namespace McCs;

public class Datapack
{
   public string packSavePath;
   public readonly string name;
   private int packFormat;
   private string description;

   public List<Function> Functions { get; } = new List<Function>();


/// <summary>
/// If packFormat is set to -1, it will set it to the newest one automatically.
/// </summary>
/// <param name="name"></param>
/// <param name="packFormat"></param>
/// <param name="description"></param>
   public Datapack(string name, int packFormat, string description = "")
   {
      this.name = name;
      this.description = description;

      if (packFormat == -1)
         GetPackFormat().Wait();
      else
         this.packFormat = packFormat;
   }
   // public Datapack(string name, int packFormat, PackFilter filter, string description = "")
   // {
   //    this.name = name;

   //    if(packFormat == -1)
   //       GetPackFormat().Wait();
   //    else
   //       this.packFormat = packFormat;
   //    //TODO Constructor
   // }
   // public Datapack(string name, int packFormat, PackOverlays overlays, string description = "")
   // {
   //    this.name = name;

   //    if (packFormat == -1)
   //       GetPackFormat().Wait();
   //    else
   //       this.packFormat = packFormat;
   //    //TODO Constructor 
   // }
   // public Datapack(string name, int packFormat, PackFilter filter, PackOverlays overlays, string description = "")
   // {
   //    this.name = name;

   //    if (packFormat == -1)
   //       GetPackFormat().Wait();
   //    else
   //       this.packFormat = packFormat;
   //    //TODO Constructor 
   // }



   private async Task GetPackFormat()
   {

      const string owner = "misode";
      const string repo = "mcmeta";
      const string filePath = "version.json";
      const string branch = "data-json";

      GitHubClient github = new GitHubClient(new ProductHeaderValue("HeDeAnTheonlyone"));

      try
      {
         Console.WriteLine("Test");
         var contents = await github.Repository.Content.GetAllContentsByRef(owner, repo, filePath, branch);
         if (contents.Count > 0)
         {
            string versionJson = contents[0].Content;
            Dictionary<string, object> versionMetaData = JsonConvert.DeserializeObject<Dictionary<string, object>>(versionJson);
            
            if (versionMetaData["data_pack_version"] != null)
            {
               packFormat = (int)(long)versionMetaData["data_pack_version"];
            }
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
      packFormat = 26;
      throw new Exception(errMessage);
   }



   public void SetSavePath()
   {
      string? input = Console.ReadLine();

      if (input == null)
         return;

      if (input.Length > 0)
         packSavePath = input;
      else
         packSavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //FIXME
   }



   public void Compile()
   {
      SetSavePath();
      packSavePath = string.Join("/", packSavePath, name);
      Console.WriteLine(packSavePath);
      DirectoryInfo packDir;

      if (Directory.Exists(packSavePath))
         packDir = new DirectoryInfo(packSavePath);
      else
         packDir = Directory.CreateDirectory(packSavePath);

      Dictionary<string, object> packMcMeta = new Dictionary<string, object>();
      Dictionary<int, int> b = new Dictionary<int, int>();
      packMcMeta.Add("a", b);
   }
}