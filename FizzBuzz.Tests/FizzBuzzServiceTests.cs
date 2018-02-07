using System;
using System.Linq;
using FizzBuzz.Domain;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private FizzBuzzService _fizzBuzzService;

        [SetUp]
        public void Setup()
        {
            _fizzBuzzService = new FizzBuzzService();
        }

        /*********************************************************
         * Word replacements tests
         * *******************************************************/
        [Test]
        public void ShouldReturnFizzForNumber3()
        {
            var result = _fizzBuzzService.GetValueForNumber(3);
            Assert.AreEqual(result, "Fizz");
        }

        [Test]
        public void ShouldReturnBuzzForNumber5()
        {
            var result = _fizzBuzzService.GetValueForNumber(5);
            Assert.AreEqual(result, "Buzz");
        }

        [Test]
        public void ShouldReturnFizzBuzzForNumber15()
        {
            var result = _fizzBuzzService.GetValueForNumber(15);
            Assert.AreEqual(result, "FizzBuzz");
        }

        [Test]
        public void ShouldReturn4ForNumber4()
        {
            var result = _fizzBuzzService.GetValueForNumber(4);
            Assert.AreEqual(result, "4");
        }

        [Test]
        public void ShouldOverwriteDefaultFizzWord()
        {
            _fizzBuzzService.AddMap(3, "Fizzy");
            
            var result = _fizzBuzzService.GetValueForNumber(3);
            
            Assert.AreEqual(result, "Fizzy");
        }

        [Test]
        public void ShouldAddNewWordNumberCombination()
        {
            _fizzBuzzService.AddMap(4, "Squirrel");

            var result = _fizzBuzzService.GetValueForNumber(4);

            Assert.AreEqual(result, "Squirrel");
        }

        [Test, ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void ShouldThrowExceptionIfMappedNumberIsNotInRange()
        {
            _fizzBuzzService.MinNumber = 10;
            _fizzBuzzService.AddMap(5, "Monkey");
        }

        [Test]
        public void ShouldReturnLastWordOnlyForDuplicateMaps()
        {
            _fizzBuzzService.AddMap(4, "Four4");
            _fizzBuzzService.AddMap(4, "Quatre444");

            _fizzBuzzService.MaxNumber = 5;

            var result = _fizzBuzzService.GetAllValues().ToList();
            Assert.AreEqual(result[3], "Quatre444");

        }
     

        /********************************************************************
         * MinNumber and MaxNumber validations         
         * ******************************************************************/
        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldGetExceptionIfNegativeNumberEnteredForMinNumber()
        {
            _fizzBuzzService.MinNumber = -100;
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldGetExceptionIfNegativeNumberEnteredForMaxNumber()
        {
            _fizzBuzzService.MaxNumber = -100;
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldGetExceptionIfMaxNumberLessThanMinNumber()
        {
            _fizzBuzzService.MaxNumber = 10;
            _fizzBuzzService.MinNumber = 11;
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldGetExceptionIfMinNumberGreaterThanMaxNumber()
        {
            _fizzBuzzService.MinNumber = 11;
            _fizzBuzzService.MaxNumber = 10;

        }

        /*****************************************************************
      * GetAllValues tests
      * ***************************************************************/

        [Test]
        public void ShouldReturnArrayOf100Strings()
        {
            var result = _fizzBuzzService.GetAllValues().ToList();

            Assert.AreEqual(result.Count, 100);
            Assert.AreEqual(result[0], "1");
            Assert.AreEqual(result[2], "Fizz");
            Assert.AreEqual(result[4], "Buzz");
            Assert.AreEqual(result[14], "FizzBuzz");
        }

        [Test]
        public void ShouldReturnArrayOf7Strings()
        {
            _fizzBuzzService.MaxNumber = 7;
            var result = _fizzBuzzService.GetAllValues().ToList();

            Assert.AreEqual(result.Count, 7);
        }



    }
}
