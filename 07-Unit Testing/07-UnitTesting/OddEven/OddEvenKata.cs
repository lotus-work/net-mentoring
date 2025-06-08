namespace OddEven
{
    public class OddEvenKata
    {
        public string CheckOddEven(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be null or empty");
            }

            if (!int.TryParse(input, out int number))
            {
                return "Invalid";
            }

            return number % 2 == 0 ? "Even" : "Odd";
        }

    }
}
