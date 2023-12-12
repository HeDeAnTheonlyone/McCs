
namespace McCs;

public class Function
{
    public readonly string Name;
    public List<Command> Commands { get; } = new List<Command>();



    public Function(string name)
    {
        Name = $"{name}.mcfunction";
    }
}