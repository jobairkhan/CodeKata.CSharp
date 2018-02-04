using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StringCalculator
{
    public class StringCalculatorTest2
    {
        [Fact]
        public void ReturnZero_WhenNumbersAreEmpty()
        {
            var calculator = new StrCalculator();

            var actual = calculator.Add("");

            Assert.Equal(0, actual);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("3", 3)]
        public void ReturnNumber_WhenSingleNumberEntered(string input, int expected)
        {
            var calculator = new StrCalculator();

            var actual = calculator.Add(input);

            Assert.Equal(expected, actual);
        }
    }

    public class StrCalculator
    {
        public int Add(string value)
        {
            return
                int.TryParse(value, out var result)
                    ? result
                    : 0;
        }
    }
}
