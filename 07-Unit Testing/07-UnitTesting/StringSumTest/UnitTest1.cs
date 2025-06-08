using StringSum;

namespace StringSumTest
{
    public class Tests
    {
        [Test]
        public void Sum_EmptyStrings_ThrowsException()
        {
            //arrange
            var num1 = string.Empty;
            var num2 = string.Empty;
            var stringSum = new StringSumKata();

            //act & assert
            Assert.Throws<ArgumentException>(() => { stringSum.Sum(num1, num2); });
        }

        [Test]
        public void Sum_SmallNaturalNumbers_ReturnsTheirSum()
        {
            //arrange
            var num1 = "5";
            var num2 = "1";
            var stringSum = new StringSumKata();
            var expected = "6";

            //act
            var actual = stringSum.Sum(num1, num2);

            //assert
            Assert.That(expected == actual);
        }

        [Test]
        public void Sum_NotANumberAndNaturalNumber_ReturnsSecondNumber()
        {
            //arrange
            var num1 = "5";
            var num2 = "abc";
            var stringSum = new StringSumKata();
            var expected = "5";

            //act
            var actual = stringSum.Sum(num1, num2);

            //assert
            Assert.That(expected == actual);
        }

        [Test]
        [TestCase("5.5", "-1", "0")]
        [TestCase("-5", "-3", "0")]
        [TestCase("10.5", "114.3", "0")]
        public void Sum_DifferentNotNaturalNumbers_ReturnsZero(string num1, string num2, string expected)
        {
            //arrange
            var stringSum = new StringSumKata();

            //act
            var actual = stringSum.Sum(num1, num2);

            //assert
            Assert.That(expected == actual);
        }
    }
}