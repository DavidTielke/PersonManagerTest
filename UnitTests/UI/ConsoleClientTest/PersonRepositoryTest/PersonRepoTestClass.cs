using System.Collections.Generic;
using ConsoleClient;

namespace UnitTests.UI.ConsoleClientTest.PersonRepositoryTest
{
    class PersonRepoTestClass : PersonRepository
    {
        protected internal override IEnumerable<Person> CallParse(string[] lines)
        {
            return new List<Person>
            {
                new Person(1,"David",32),
                new Person(2,"Lena",30)
            };
        }

        public PersonRepoTestClass(IFileSystem fileSystem) : 
            base(fileSystem)
        {
        }
    }
}