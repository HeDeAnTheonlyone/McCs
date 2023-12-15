using McCs;

public static class Program
{
    public static void Main(string[] args)
    {        

        PackFilter filter = new PackFilter
        (
            new PackPath("spellAssembly", "recipes"),
            new PackPath("eom", "functions")
        );

        Datapack pack = new Datapack("newPack", [4, -1], filter);
        
        //Function func = new Function("tick");

        //pack.Functions.Add(func);

        pack.Compile();
    }
}