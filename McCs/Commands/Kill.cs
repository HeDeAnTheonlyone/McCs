using McCs;

public class Kill : Command
{
    public string selector;
    public string Selector { get; set; }



    public Kill() => this.selector = "";
    public Kill(Selector selector) => this.selector = selector.ToString();



    public override string ToString() => selector == "" ? "/kill" : $"/kill {selector}";
}