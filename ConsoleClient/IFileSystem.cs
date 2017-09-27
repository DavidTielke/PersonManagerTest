namespace ConsoleClient
{
    public interface IFileSystem
    {
        string[] OpenAndRead(string path);
    }
}