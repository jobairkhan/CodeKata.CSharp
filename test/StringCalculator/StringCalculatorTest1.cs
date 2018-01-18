using Xunit;

namespace StringCalculator
{
    public class StringCalculatorTest1
    {
        private readonly Calculator _calculator;

        public StringCalculatorTest1()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void EmptyStringReturns0()
        {
            var actual = _calculator.Add(string.Empty);

            Assert.Equal(0, actual);
        }

        [Theory]
        [InlineData("1", 1)][InlineData("2", 2)][InlineData("3", 3)]
        public void OneReturnsOne(string value, int expected)
        {
            var actual = _calculator.Add(value);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,2", 3)]
        public void CommaSeparatedValueReturnsSum(string value, int expected)
        {
            var actual = _calculator.Add(value);

            Assert.Equal(expected, actual);
        }
    }
    public class Calculator
    {
        public int Add(string value)
        {
            if (int.TryParse(value, out var result))
            {
                return result;
            }
            return 0;
        }
    }
}
