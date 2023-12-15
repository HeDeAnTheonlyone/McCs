using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace McCs;

public class PackFilter
{
   public Dictionary<string, object> filter = new Dictionary<string, object>(); 
   private Dictionary<string, string>[] block;
   
   public PackFilter(params PackPath[] packPaths)
   {
      block = new Dictionary<string, string>[packPaths.Length];

      for (int i = 0; i < packPaths.Length; i++)
      {
         block[i] = new Dictionary<string, string>
         {
            { "namespace", packPaths[i].Namespace },
            { "path", packPaths[i].Path }
         };
      }

      filter.Add("block", block);
   }
}