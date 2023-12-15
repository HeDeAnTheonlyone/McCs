
namespace McCs;

public class Function
{
    public readonly string Name;
    public List<Command> Commands { get; } = new List<Command>();



    public Function(string name)
    {
        switch(name)
        {
            case "tick":
                AddToTickList();
                break;

            case "load":
                AddToLoadList();
                break;

            default:
                
                break;
                

            
        }
        Name = $"{name}.mcfunction";
    }



    private void AddToLoadList()
    {
        DirectoryInfo dirInf = new DirectoryInfo($"{Datapack.packSavePath}/minecraft");
    }



    private void AddToTickList()
    {
        //TODO
    }
}