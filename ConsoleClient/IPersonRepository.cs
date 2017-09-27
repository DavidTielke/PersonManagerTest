using System.Linq;

namespace ConsoleClient
{
    public interface IPersonRepository
    {
        IQueryable<Person> Load();
    }
}