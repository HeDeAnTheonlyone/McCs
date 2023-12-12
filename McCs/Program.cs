using McCs;

public static class Program
{
    public static void Main(string[] args)
    {
        Datapack pack = new Datapack("newPack", 26);

        Function func = new Function("tick");

        pack.Functions.Add(func);

        string[] selArgs = ["type=item", "distance=..5"];

        func.Commands.Add(new Kill(new Selector("@s")));
        func.Commands.Add(new Kill(new Selector("@p")));
        func.Commands.Add(new Kill(new Selector("@e", selArgs)));
        func.Commands.Add(new Kill(new Selector("@a")));

        pack.Compile();
    }
}