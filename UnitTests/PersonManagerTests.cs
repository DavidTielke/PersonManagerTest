using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClient;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class PersonManagerTests
    {
        private PersonManager _manager;
        private PersonRepoStub _stub;

        [SetUp]
        public void SetUp()
        {
            _stub = new PersonRepoStub();
            _manager = new PersonManager(_stub);
        }

        [Test]
        public void GetAllChildren_2Adults2Children_2ChildrenReturned()
        {
            _stub.Persons = new List<Person>
            {
                new Person(1,"hugo",18),
                new Person(2,"alex",17),
                new Person(3,"hugo",5),
                new Person(4,"hugo",28),
            };
            var expected = 2;

            var actual = _manager.GetAllChildren().Count();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllChildren_4Adults0Children_EmptyList()
        {
            _stub.Persons = new List<Person>
            {
                new Person(1,"hugo",18),
                new Person(2,"alex",22),
                new Person(3,"hugo",18),
                new Person(4,"hugo",28),
            };
            var expected = 0;

            var actual = _manager.GetAllChildren().Count();

            Assert.AreEqual(expected, actual);
        }
    }

    public class PersonRepoStub : IPersonRepository
    {
        public List<Person> Persons { get; set; }

        public PersonRepoStub()
        {
            Persons = new List<Person>();
        }

        public IQueryable<Person> Load() => Persons.AsQueryable();
    }
}
