using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClient;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class FileSystemIntegrationTest
    {
        private readonly string _folder = Path.GetTempPath();
        private readonly string _file = Path.Combine(Path.GetTempPath(), "test.csv");

        [OneTimeSetUp]
        public void OneTimeStup()
        {
            if (!Directory.Exists(_folder))
            {
                Directory.CreateDirectory(_folder);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            if (Directory.Exists(_folder))
            {
                Directory.Delete(_folder);
            }
        }

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_file))
            {
                File.Delete(_file);
            }
        }

        [Test]
        public void OpenAndRead_NoFileExist_FileNotFoundException()
        {
            var fs = new FileSystem();

            Assert.Throws<FileNotFoundException>(() => fs.OpenAndRead(_file));
        }



        [Test]
        public void OpenAndRead_EmptyFileExist_EmptyCollection()
        {
            File.WriteAllText(_file,"");
            var fs = new FileSystem();

            var lines = fs.OpenAndRead(_file);

            Assert.AreEqual(0, lines.Length);
        }


        [Test]
        public void OpenAndRead_FileWithTwoLines_CollectionWithTwoElements()
        {
            File.WriteAllLines(_file, new[]
            {
                "hallo",
                "welt"
            });
            var fs = new FileSystem();

            var lines = fs.OpenAndRead(_file);

            Assert.AreEqual(2, lines.Length);
        }

        [Test]
        public void OpenAndRead_FileWithHalloNLWelt_CollectionWithHalloAndWelt()
        {
            File.WriteAllLines(_file, new[]
            {
                "Hallo",
                "Welt"
            });
            var fs = new FileSystem();

            var lines = fs.OpenAndRead(_file).ToArray();
            Assert.Multiple(() =>
            {
                Assert.AreEqual("Hallo", lines[0]);
                Assert.AreEqual("Welt", lines[1]);
            });
        }
    }
}
