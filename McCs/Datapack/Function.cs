
namespace McCs;

public class Function
{
    public readonly string Name;
    public List<Command> Commands { get; } = new List<Command>();



    public Function(string name, FunctionType type = FunctionType.Default)
    {
        DirectoryInfo dirInf = new DirectoryInfo(Datapack.packSavePath);

        switch(type)
        {
            case FunctionType.Tick:
                AddToTickList();
                break;

            case FunctionType.Load:
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