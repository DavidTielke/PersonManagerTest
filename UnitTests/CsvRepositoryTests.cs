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
    public class CsvRepositoryTests
    {
        [Test]
        public void Parse_InputIsNull_ArgumentNullException()
        {
            var parser = new CsvParser();

            Assert.Throws<ArgumentNullException>(() => parser.Parse(null));
        }

        [Test]
        public void Parse_InputIsEmpty_ResultIsEmpty()
        {
            var parser = new CsvParser();
            var lines = new string[0];

            var result = parser.Parse(lines);

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void Parse_OneValidPerson_OnePersonParsed()
        {
            var parser = new CsvParser();
            var lines = new[]
            {
                "1,David,32"
            };

            var persons = parser.Parse(lines).ToArray();

            CollectionAssert.IsNotEmpty(persons);
            Assert.AreEqual(1, persons[0].Id);
            Assert.AreEqual("David", persons[0].Name);
            Assert.AreEqual(32, persons[0].Age);
        }

        [Test]
        public void Parse_TwoValidPerson_TwoPersonParsed()
        {
            var parser = new CsvParser();
            var lines = new[]
            {
                "1,David,32",
                "2,Lena,30"
            };

            var persons = parser.Parse(lines).ToArray();

            Assert.AreEqual(2, persons.Length);
            Assert.AreEqual(1, persons[0].Id);
            Assert.AreEqual("David", persons[0].Name);
            Assert.AreEqual(32, persons[0].Age);
            Assert.AreEqual(2, persons[1].Id);
            Assert.AreEqual("Lena", persons[1].Name);
            Assert.AreEqual(30, persons[1].Age);
        }

        [Test]
        [TestCase("1,David", typeof(FormatException))]
        [TestCase("1", typeof(FormatException))]
        [TestCase("1,David,a", typeof(FormatException))]
        [TestCase("a,David,1", typeof(FormatException))]
        [TestCase(" ", typeof(FormatException))]
        [TestCase("", typeof(FormatException))]
        public void Parse_OneInvalidPerson(string input, Type exceptionType)
        {
            var lines = new[] {input};
            var parser = new CsvParser();

            Assert.Throws(exceptionType, () => parser.Parse(lines));
        }
    }
}
