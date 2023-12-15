
namespace McCs;

public struct PackPath
{
    public readonly string Namespace;
    public readonly string Path;



    public PackPath(string _namespace, string path)
    {
        Namespace = _namespace;
        Path = path;
    }



    public override string ToString() => $"{Namespace}:{Path}";
}