using System;
using FluentAssertions;
using Xunit;

namespace Kata.MarsRover.Tests
{
    public class InputParser : IInputParser {
        public Grid Parse(string inputString)
        {
            var size = inputString.Split(" ");
            int.TryParse(size[0], out var height);
            return new Grid{Height = height };
        }
    }

    public class Grid
    {
        public int Height { get; set; }
    }

    public class InputParserShould
    {
        [Theory]
        [InlineData("10 5", 10)]
        [InlineData("5 5", 5)]
        public void Return_grid_height(string input, int expectedHeight)
        {
            var inputParser = new InputParser();
            var grid = inputParser.Parse(input);
            grid.Height.Should().Be(expectedHeight);
        }
    }
}