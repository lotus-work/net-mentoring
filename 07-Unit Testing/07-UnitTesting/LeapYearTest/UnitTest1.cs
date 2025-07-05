using LeapYear;
using NUnit.Framework;
namespace LeapYearTest
{
    public class Tests
    {
        [Test]
        public void LeapYear_NonDivisibleBy4_ReturnsFalse()
        {
            //arrange
            var yearChecker = new LeapYearKata(); 

            //act
            var actual = yearChecker.IsLeapYear(5);

            //assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void LeapYear_DivisibleBy4AndNonDivisibleBy100AndNonDivisibleBy400_ReturnsTrue()
        {
            //arrange
            var yearChecker = new LeapYearKata();

            //act
            var actual = yearChecker.IsLeapYear(1996);

            //assert
            Assert.IsTrue(actual);
        }

        [Test]
        [TestCase(2001, false)]
        [TestCase(1996, true)]
        [TestCase(1900, false)]
        [TestCase(2000, true)]
        public void LeapYear_VariousLeapAndCommonYears_ReturnsRespectively(int number, bool expected)
        {
            //arrange
            var yearChecker = new LeapYearKata();

            //act
            var actual = yearChecker.IsLeapYear(number);

            //assert
            Assert.That(actual == expected);
        }
    }
}