using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileSystem = new FileSystem();
            var repo = new PersonRepository(fileSystem);
            var manager = new PersonManager(repo);

            var adults = manager.GetAllAdults();
            var children = manager.GetAllChildren();

            PrintPeopleTable(adults, "Erwachsene");
            PrintPeopleTable(children, "Kinder");

            Console.ReadKey();
        }

        private static void PrintPeopleTable(IQueryable<Person> people, string title)
        {
            Console.WriteLine($"## {title} ({people.Count()}) ##");
            people.ToList().ForEach(p => Console.WriteLine($"{p.Id,-3} {p.Name,-10} {p.Age,3}"));
        }
    }
}
