using System.Linq;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz.Tests
{
    [TestClass]
    public class FizzBuzzServiceTests
    {
        private FizzBuzzService _fizzBuzzService;

        [TestInitialize]
        public void Setup()
        {
            _fizzBuzzService = new FizzBuzzService();
        }

        [TestMethod]
        public void ShouldReturnFizzForNumber3()
        {
            _fizzBuzzService.SetToDefaultValues();        
            var result = _fizzBuzzService.GetValueForNumber(3);
            Assert.AreEqual(result, "Fizz");
        }

        [TestMethod]
        public void ShouldReturnBuzzForNumber5()
        {
            _fizzBuzzService.SetToDefaultValues();
            var result = _fizzBuzzService.GetValueForNumber(5);
            Assert.AreEqual(result, "Buzz");
        }

        [TestMethod]
        public void ShouldReturnFizzBuzzForNumber15()
        {
            _fizzBuzzService.SetToDefaultValues();
            var result = _fizzBuzzService.GetValueForNumber(15);
            Assert.AreEqual(result, "FizzBuzz");
        }

        [TestMethod]
        public void ShouldReturn4ForNumber4()
        {
            _fizzBuzzService.SetToDefaultValues();
            var result = _fizzBuzzService.GetValueForNumber(4);
            Assert.AreEqual(result, "4");
        }

        [TestMethod]
        public void ShouldReplaceDefaultFizzWord()
        {
            _fizzBuzzService.SetToDefaultValues();
            _fizzBuzzService.AddMap(3, "Fizzy");
            
            var result = _fizzBuzzService.GetValueForNumber(3);
            
            Assert.AreEqual(result, "Fizzy");
        }

        [TestMethod]
        public void ShouldReturnArrayOfMaxNumberLength()
        {
            _fizzBuzzService.SetToDefaultValues();

            var result = _fizzBuzzService.GetAllValues().ToList();
            
            Assert.AreEqual(result.Count, 100);
            Assert.AreEqual(result[0], "1");
            Assert.AreEqual(result[2], "Fizz");
            Assert.AreEqual(result[4], "Buzz");
            Assert.AreEqual(result[14], "FizzBuzz");
        }

    }
}
