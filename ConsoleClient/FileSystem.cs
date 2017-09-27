using System.IO;

namespace ConsoleClient
{
    public class FileSystem : IFileSystem
    {
        public string[] OpenAndRead(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}