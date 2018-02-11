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
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("3", 3)]
        public void OneReturnsOne(string value, int expected)
        {
            var actual = _calculator.Add(value);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("1,1,1,1", 4)]
        public void CommaSeparatedValueReturnsSum(string value, int expected)
        {
            var actual = _calculator.Add(value);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NumbersSeperatedByNewLinesReturnSum()
        {
            var actual = _calculator.Add("1\n1");

            Assert.Equal(2, actual);
        }
    }
    public class Calculator
    {
        private const char SeperatorComma = ',';
        private const char SeperatorNewLine = '\n';
        private readonly char[] _separator = { SeperatorComma, SeperatorNewLine };

        public int Add(string value)
        {
            var sum = 0;
            foreach (var item in value.Split(_separator))
            {
                if (int.TryParse(item, out var result))
                {
                    sum += result;
                }
            }
            return sum;
        }
    }
}
