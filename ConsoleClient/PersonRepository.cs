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

        public DateTime LastTimeLoaded { get; private set; }

        public PersonRepository(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public IQueryable<Person> Load()
        {
            LastTimeLoaded = DateTime.Now;

            var lines = _fileSystem.OpenAndRead("data.csv");

            var persons = CallParse(lines);
            
            return persons.AsQueryable();
        }

        // Extract and Override (EaO)
        protected internal virtual IEnumerable<Person> CallParse(string[] lines)
        {
            var parser = new CsvParser();
            var persons = parser.Parse(lines);
            Add(1, 2);
            return persons;
        }

        private long Add(int z1, int z2)
        {
            return (long) z1 + z2;
        }
    }
}
