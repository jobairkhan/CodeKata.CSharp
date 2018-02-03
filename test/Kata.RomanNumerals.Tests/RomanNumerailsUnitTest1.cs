using Xunit;

namespace Kata.RomanNumerals.Tests
{
    public class RomanNumerailsUnitTest1
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(5, "V")]
        public void ConvertIntToRoman(int input, string expected)
        {
            var sut = new RomanNumeral1();

            var actual = sut.Convert(input);

            Assert.Equal(expected, actual);
        }
    }
    public class RomanNumeral1
    {
        public string Convert(int number)
        {
            var result = "";
            for (var index = 1; index <= number; index++)
            {
                result += "I";
            }
            return result;
        }
    }
}