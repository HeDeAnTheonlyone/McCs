using McCs;

public static class Program
{
    public static void Main(string[] args)
    {
        string[] selArgs = ["type=player", "tag=test", "distance=..1"];
        Kill cmd = new Kill();
        Console.WriteLine(cmd.ToString());
    }
}