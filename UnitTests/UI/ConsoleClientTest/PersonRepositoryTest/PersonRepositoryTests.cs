using NUnit.Framework;
using UnitTests.Stubs;

namespace UnitTests.UI.ConsoleClientTest.PersonRepositoryTest
{
    [TestFixture()]
    public partial class PersonRepositoryTests
    {
        private PersonRepoTestClass _repo;
        private FileSystemStub _fileSystemStub;

        [SetUp]
        public void SetUp()
        {
            _fileSystemStub = new FileSystemStub();
            _repo = new PersonRepoTestClass(_fileSystemStub);
        }
    }
}
