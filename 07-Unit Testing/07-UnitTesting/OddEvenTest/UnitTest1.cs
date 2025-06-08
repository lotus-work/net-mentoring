using OddEven;

namespace OddEvenTest
{
    public class Tests
    {
        [Test]
        public void CheckOddEven_EmptyString_ThrowsException()
        {
            // arrange
            var kata = new OddEvenKata();
            var input = "";

            // act & assert
            Assert.Throws<ArgumentException>(() => kata.CheckOddEven(input));
        }

        [Test]
        public void CheckOddEven_ValidEvenNumber_ReturnsEven()
        {
            // arrange
            var kata = new OddEvenKata();
            var input = "10";
            var expected = "Even";

            // act
            var actual = kata.CheckOddEven(input);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CheckOddEven_ValidOddNumber_ReturnsOdd()
        {
            // arrange
            var kata = new OddEvenKata();
            var input = "7";
            var expected = "Odd";

            // act
            var actual = kata.CheckOddEven(input);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CheckOddEven_InvalidInput_ReturnsInvalid()
        {
            // arrange
            var kata = new OddEvenKata();
            var input = "abc";
            var expected = "Invalid";

            // act
            var actual = kata.CheckOddEven(input);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("-3", "Odd")]
        [TestCase("0", "Even")]
        [TestCase("1000001", "Odd")]
        public void CheckOddEven_MultipleCases_ReturnsExpected(string input, string expected)
        {
            // arrange
            var kata = new OddEvenKata();

            // act
            var actual = kata.CheckOddEven(input);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}