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
            return (new Grid(height, width), new Position(positionX, 0));
        }
    }

    public record Position(int x, int y);

    public record Grid(int height, int width);

    public class InputParserShould {

        [Theory, MemberData(nameof(GetInputVerifyHeight))]
        public void Return_grid_with_correct_height(string input, int expectedHeight) {
            var inputParser = new InputParser();
            var (grid, _) = inputParser.Parse(input);
            grid.height.Should().Be(expectedHeight);
        }

        [Theory, MemberData(nameof(GetInputVerifyWidth))]
        public void Return_grid_with_correct_width(string input, int expectedWidth) {
            var inputParser = new InputParser();
            var (grid, _) = inputParser.Parse(input);
            grid.width.Should().Be(expectedWidth);
        }

        [Theory, MemberData(nameof(GetInputVerifyPositionX))]
        public void Return_grid_with_correct_position_x(string input, int expectedX) {
            var inputParser = new InputParser();
            var (_, initialPosition) = inputParser.Parse(input);
            initialPosition.x.Should().Be(expectedX);
        }

        [Theory, MemberData(nameof(GetInputVerifyPositionY))]
        public void Return_grid_with_correct_position_y(string input, int expectedY) {
            var inputParser = new InputParser();
            var (_, initialPosition) = inputParser.Parse(input);
            initialPosition.x.Should().Be(expectedY);
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

        public static IEnumerable<object[]> GetInputVerifyPositionY() {
            yield return new object[] { "1 1" + Environment.NewLine + "0 1 N", 1 };
            yield return new object[] { "1 1" + Environment.NewLine + "0 10 N", 10 };
        }
    }
}