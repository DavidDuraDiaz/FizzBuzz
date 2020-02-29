using FizzBuzzWeb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace FizzBuzzWebTest
{
    [TestClass]
    public class FizzBuzzControllerTest
    {
        private Dictionary<int, string> GetDummyDictionary()
        {
            return new Dictionary<int, string>() {
                {3,"word1"},
                {5,"word2"}
            };
        }

        [TestMethod]
        public async Task ShouldReturnCorrectFizzBuzz()
        {
            //Arrange
            var start = 0;
            var fizzBuzzService = new FizzBuzzService.Services.FizzBuzzService();
            var controller = new FizzBuzzController(fizzBuzzService);

            //Act
            var result = await controller.GetAsync(start) as OkNegotiatedContentResult<List<string>>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Count, 100);
        }

        [TestMethod]
        public void ShouldReturnCorrectHundredTimesFizzBuzz()
        {
            //Arrange
            var start = 0;
            var fizzBuzzService = new FizzBuzzService.Services.FizzBuzzService();
            var controller = new FizzBuzzController(fizzBuzzService);

            var TaskList = new List<Task<IHttpActionResult>>();

            //Act
            for (var i = 0; i < 100; i++)
            {
                var result = controller.GetAsync(start);
                TaskList.Add(result);
            }

            Task.WaitAll(TaskList.ToArray());

            //Assert
            TaskList.ForEach(o =>
                Assert.AreEqual(
                        ((OkNegotiatedContentResult<List<string>>)o.Result).Content.Count
                        , 100));
        }

        [TestMethod]
        public async Task ShouldReturnRangeException()
        {
            //Arrange
            var start = 101;
            var fizzBuzzService = new FizzBuzzService.Services.FizzBuzzService();
            var controller = new FizzBuzzController(fizzBuzzService);

            //Act
            var result = await controller.GetAsync(start);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

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
            var start = 0;
            var fizzBuzzService = new FizzBuzzService.Services.FizzBuzzService();
            var controller = new FizzBuzzController(fizzBuzzService);

            //Act
            var result = await controller.GetAsync(start) as OkNegotiatedContentResult<List<string>>;

            //Assert
            //Assert.AreEqual(result.Content.Count, 100);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(new DirectoryInfo(@"C:\FizzBuzz\Persist\").GetFiles().Length, 1);
        }
    }
}
