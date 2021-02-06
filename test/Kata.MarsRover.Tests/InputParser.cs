using System;
using FluentAssertions;
using Xunit;

namespace Kata.MarsRover.Tests
{
    public class InputParser : IInputParser {
        public Grid Parse(string inputString)
        {
            return new Grid{Height = 5};
        }
    }

    public class Grid
    {
        public int Height { get; set; }
    }

    public class InputParserShould
    {
        [Fact]
        public void Return_grid()
        {
            var inputParser = new InputParser();
            var grid = inputParser.Parse("5 5");
            grid.Height.Should().Be(5);
        }
    }
}