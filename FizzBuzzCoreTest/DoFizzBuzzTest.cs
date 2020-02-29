using FizzBuzzCore;
using FizzBuzzCore.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzzCoreTest
{
    [TestClass]
    public class DoFizzBuzzTest
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
            var limit = 10;
            var fizzBuzzParams = GetDummyDictionary();

            //Act
            var result = await FizzBuzz.DoFizzBuzzAsync(start, fizzBuzzParams, limit);

            //Assert
            Assert.AreEqual(result.Count, 10);
        }

        [TestMethod]
        public async Task ShouldReturnRangeException()
        {
            //Arrange
            var start = 11;
            var limit = 10;
            var fizzBuzzParams = GetDummyDictionary();

            //Act
            //Assert
            await Assert.ThrowsExceptionAsync<InvalidRangeException>(async () => { var Result = await FizzBuzz.DoFizzBuzzAsync(start, fizzBuzzParams, limit); });
        }

        [TestMethod]
        public async Task ShouldReturnKeyException()
        {
            //Arrange
            var start = 0;
            var limit = 10;
            var fizzBuzzParams = GetDummyDictionary();
            fizzBuzzParams.Add(0, "wrongKey");

            //Act
            //Assert
            await Assert.ThrowsExceptionAsync<InvalidKeyException>(async () => { var Result = await FizzBuzz.DoFizzBuzzAsync(start, fizzBuzzParams, limit); });
        }
    }
}
