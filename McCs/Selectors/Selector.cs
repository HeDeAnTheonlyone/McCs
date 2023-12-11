
namespace McCs.Selectors;

public class Selector 
{
   string Target { get; set; }
   string[] Args { get; set; }



   public Selector(string target = "@s")
   {
      Target = target;
      Args = Array.Empty<string>();
   }



   public Selector(string[] args, AtSelector target = AtSelector.s)
   {
      Selector sel = new Selector(target);
      Args = new string[args.Length];
      Args = args; 
   }
}