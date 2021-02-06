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
        [Fact]
        public void Return_grid()
        {
            var inputParser = new InputParser();
            var grid = inputParser.Parse("5 5");
            grid.Height.Should().Be(5);
        }

        [Fact]
        public void Return_grid_height()
        {
            var inputParser = new InputParser();
            var grid = inputParser.Parse("10 5");
            grid.Height.Should().Be(10);
        }
    }
}