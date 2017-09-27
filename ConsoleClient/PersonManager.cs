using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class PersonManager
    {
        private readonly IPersonRepository _repository;

        public PersonManager(IPersonRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Person> GetAllAdults()
        {
            return _repository.Load().Where(p => p.Age >= 18);
        }

        public IQueryable<Person> GetAllChildren()
        {
            return _repository.Load().Where(p => p.Age < 18);
        }
    }
}
