using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClient;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace UnitTests
{
    [TestFixture()]
    public class PersonRepositoryTests
    {
        private PersonRepoTest _repo;
        private FileSystemStub _fileSystemStub;

        [SetUp]
        public void SetUp()
        {
            _fileSystemStub = new FileSystemStub();
            _repo = new PersonRepoTest(_fileSystemStub);
        }

        [Test]
        public void Test1()
        {
            _repo.Load();
        }
    }

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

    class PersonRepoTest : PersonRepository
    {
        protected override IEnumerable<Person> CallParse(string[] lines)
        {
            return new List<Person>
            {
                new Person(1,"David",32),
                new Person(2,"Lena",30)
            };
        }

        public PersonRepoTest(IFileSystem fileSystem) : 
            base(fileSystem)
        {
        }
    }
}
