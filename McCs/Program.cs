using McCs.Selectors;

namespace McCs;

public static class Program
{
    public static void Main(string[] args)
    {
        string[] selArgs = ["type=player", "tag=test", "distance=..1"];

        Selector sel = new Selector(selArgs);
        Console.WriteLine(sel.ToString());
    }
}