using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class PersonRepository : IPersonRepository
    {
        private IFileSystem _fileSystem;

        public PersonRepository(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public IQueryable<Person> Load()
        {
            var lines = _fileSystem.OpenAndRead("data.csv");

            var persons = CallParse(lines);
            
            return persons.AsQueryable();
        }

        // Extract and Override (EaO)
        protected virtual IEnumerable<Person> CallParse(string[] lines)
        {
            var parser = new CsvParser();
            var persons = parser.Parse(lines);
            return persons;
        }
    }
}
