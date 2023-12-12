
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



   public Selector(string[] args, string target = "@s")
   {
      Target = target;
      Args = new string[args.Length];
      Args = args; 
   }



   public override string ToString()
   {
      string output;

      if (Args.Length > 0)
      {
         output = $"{Target}[";

         for (int i = 0; i < Args.Length; i++)
         {
            if(i == Args.Length - 1)
               output = $"{output}{Args[i]}";
            else
               output = $"{output}{Args[i]},";
         }

         output = $"{output}]";
      }
      else
      {
         output = Target;
      }

      return output;
   }
}