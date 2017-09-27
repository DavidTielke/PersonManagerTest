using ConsoleClient;

namespace UnitTests.Stubs
{
    class FileSystemStub : IFileSystem
    {
        public string[] OpenAndRead(string path)
        {
            return new[]
            {
                "1,David,32",
                "2,Lena,30"
            };
        }
    }
}