using McCs;

public class Kill : Command
{
    private string selector;
    private string Selector { get; set; }



    public Kill() => selector = "";
    public Kill(Selector selector) => this.selector = selector.ToString();



    public override string ToString() => selector == "" ? "/kill" : $"/kill {selector}";
}