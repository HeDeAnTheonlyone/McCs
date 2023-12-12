
namespace McCs;

public class Selector 
{
   string Target { get; set; }
   string[] Args { get; set; }



   public Selector(string target = "@s")
   {
      Target = target;
      Args = Array.Empty<string>();
   }
   public Selector(string[] args)
   {
      Target = "@s";
      Args = args;
   }
   public Selector(string target, string[] args)
   {
      Target = target;
      Args = args; 
   }



   public override string ToString()
   {
      string output = Target;

      if (Args.Length > 0)
      {
         output += $"[{string.Join(", ", Args)}]";
      }

      return output;
   }
}