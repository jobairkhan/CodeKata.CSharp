using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using static System.Int32;

namespace Kata.MarsRover.Tests
{
    public class InputParser : IInputParser {
        public (Grid, Position) Parse(string inputString)
        {
            var size = inputString.Split(" ");
            TryParse(size[0], out var height);
            TryParse(size[1], out var width);
            return (new Grid{Height = height, Width = width }, new Position());
        }
    }

    public class Position
    {
        public int X { get; set; }
    }

    public class Grid
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }

    public class InputParserShould
    {
        [Theory]
        [InlineData("10 5", 10)]
        [InlineData("5 5", 5)]
        public void Return_grid_with_correct_height(string input, int expectedHeight)
        {
            var inputParser = new InputParser();
            var (grid, _) = inputParser.Parse(input);
            grid.Height.Should().Be(expectedHeight);
        }

        [Theory]
        [InlineData("1 1", 1)]
        [InlineData("10 10", 10)]
        public void Return_grid_with_correct_width(string input, int expectedWidth)
        {
            var inputParser = new InputParser();
            var (grid, _) = inputParser.Parse(input);
            grid.Width.Should().Be(expectedWidth);
        }

        [Theory, MemberData(nameof(GetInput))]
        public void Return_grid_with_correct_position(string input, int expectedX)
        {
            var inputParser = new InputParser();
            var (_, initialPosition) = inputParser.Parse(input);
            initialPosition.X.Should().Be(expectedX);
        }

        public static IEnumerable<object[]> GetInput()
        {
            yield return new object[] {"1 1" + Environment.NewLine + "1 0 N", 1};
        }
    }
}