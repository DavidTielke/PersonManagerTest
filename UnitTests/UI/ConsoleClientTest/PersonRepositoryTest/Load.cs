using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTests.UI.ConsoleClientTest.PersonRepositoryTest
{
    public partial class PersonRepositoryTests
    {
        [Test]
        public void Test1()
        {
            _repo.Load();
        }
    }
}
