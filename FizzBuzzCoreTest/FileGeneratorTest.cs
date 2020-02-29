using FizzBuzzCore;
using FizzBuzzCore.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FizzBuzzCoreTest
{
    [TestClass]
    public class FileGeneratorTest
    {

        private void DeleteContentDirectory()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\FizzBuzz\Persist\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        [TestMethod]
        public async Task ShouldCreateFile()
        {
            //Arrange
            DeleteContentDirectory();
            var dataToPersist = new List<string>() {
                "word1",
                "word2",
                "word3",
                "word4",
                "word5",
            }; ;

            //Act
            await FileGenerator.PersistToFile(dataToPersist);

            //Assert
            Assert.AreEqual(new DirectoryInfo(@"C:\FizzBuzz\Persist\").GetFiles().Length, 1);
        }
    }
}
