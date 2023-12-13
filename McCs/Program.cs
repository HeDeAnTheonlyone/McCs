using McCs;

public static class Program
{
    public static void Main(string[] args)
    {
        Datapack pack = new Datapack("newPack", 26);

        Function func = new Function("tick");

        pack.Functions.Add(func);

        pack.Compile();
    }
}