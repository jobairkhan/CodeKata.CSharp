using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using static System.Int32;

namespace Kata.MarsRover.Tests {
    public class InputParser : IInputParser {
        public (Grid, Position) Parse(string inputString) {
            var lines = inputString.Split(Environment.NewLine);
            var size = lines[0].Split(" ");
            TryParse(size[0], out var height);
            TryParse(size[1], out var width);
            
            
            var position = lines[1].Split(" ");
            TryParse(position[0], out var positionX);
            return (new Grid { Height = height, Width = width }, new Position { X = positionX });
        }
    }

    public class Position {
        public int X { get; set; }
    }

    public class Grid {
        public int Height { get; set; }
        public int Width { get; set; }
    }

    public class InputParserShould {

        [Theory, MemberData(nameof(GetInputVerifyHeight))]
        public void Return_grid_with_correct_height(string input, int expectedHeight) {
            var inputParser = new InputParser();
            var (grid, _) = inputParser.Parse(input);
            grid.Height.Should().Be(expectedHeight);
        }

        [Theory, MemberData(nameof(GetInputVerifyWidth))]
        public void Return_grid_with_correct_width(string input, int expectedWidth) {
            var inputParser = new InputParser();
            var (grid, _) = inputParser.Parse(input);
            grid.Width.Should().Be(expectedWidth);
        }

        [Theory, MemberData(nameof(GetInputVerifyPositionX))]
        public void Return_grid_with_correct_position(string input, int expectedX) {
            var inputParser = new InputParser();
            var (_, initialPosition) = inputParser.Parse(input);
            initialPosition.X.Should().Be(expectedX);
        }

        public static IEnumerable<object[]> GetInputVerifyHeight() {
            yield return new object[] { "5 5" + Environment.NewLine + "1 0 N", 5 };
            yield return new object[] { "10 10" + Environment.NewLine + "1 0 N", 10 };
        }
        public static IEnumerable<object[]> GetInputVerifyWidth() {
            yield return new object[] { "1 1" + Environment.NewLine + "1 0 N", 1 };
            yield return new object[] { "1 10" + Environment.NewLine + "1 0 N", 10 };
        }
        public static IEnumerable<object[]> GetInputVerifyPositionX() {
            yield return new object[] { "1 1" + Environment.NewLine + "1 0 N", 1 };
            yield return new object[] { "1 1" + Environment.NewLine + "10 0 N", 10 };
        }
    }
}