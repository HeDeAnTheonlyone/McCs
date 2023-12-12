

using McCs.Commands;
using McCs.Selectors;

public class Kill : Command
{
   public readonly string selector;
   public string Selector { get; set; }
   public Kill(Selector selector)
   {

   }



   public override string ToCommand()
   {
      return null;
   }
}