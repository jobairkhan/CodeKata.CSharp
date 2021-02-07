using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using static System.Int32;

namespace Kata.MarsRover.Tests {
    public class InputParser : IInputParser {
        public (Grid, Position, string) Parse(string inputString) {
            var lines = inputString.Split(Environment.NewLine);
            var size = lines[0].Split(" ");
            TryParse(size[0], out var height);
            TryParse(size[1], out var width);
            
            
            var position = lines[1].Split(" ");
            TryParse(position[0], out var positionX);
            TryParse(position[1], out var positionY);
            
            return (new Grid(height, width), new Position(positionX, positionY), lines[2]);
        }
    }

    public record Position(int X, int Y);

    public record Grid(int Height, int Width);

    public class InputParserShould {
        private readonly InputParser _sut;

        public InputParserShould()
        {
            _sut = new InputParser();
        }

        [Theory, MemberData(nameof(GetInputVerifyHeight))]
        public void Return_grid_with_correct_height(string input, int expectedHeight) {
            var (grid, _, _) = _sut.Parse(input);
            grid.Height.Should().Be(expectedHeight);
        }

        [Theory, MemberData(nameof(GetInputVerifyWidth))]
        public void Return_grid_with_correct_width(string input, int expectedWidth) {
            var (grid, _, _) = _sut.Parse(input);
            grid.Width.Should().Be(expectedWidth);
        }

        [Theory, MemberData(nameof(GetInputVerifyPositionX))]
        public void Return_grid_with_correct_position_x(string input, int expectedX) {
            var (_, initialPosition, _) = _sut.Parse(input);
            initialPosition.X.Should().Be(expectedX);
        }

        [Theory, MemberData(nameof(GetInputVerifyPositionY))]
        public void Return_grid_with_correct_position_y(string input, int expectedY) {
            var (_, initialPosition, _) = _sut.Parse(input);
            initialPosition.Y.Should().Be(expectedY);
        }

        [Theory, MemberData(nameof(GetInputVerifyCommands))]
        public void Return_grid_with_correct_commands(string input, string expectedCmdString) {
            var inputParser = new InputParser();
            var (_, _, cmd) = inputParser.Parse(input);
            cmd.Should().Be(expectedCmdString);
        }

        private static string AllOne => "1 1" + Environment.NewLine + "1 1 N" + Environment.NewLine + "LRM";
        private static string AllFive => "5 5" + Environment.NewLine + "5 5 N" + Environment.NewLine + "RRR";
        private static string AllTen => "10 10" + Environment.NewLine + "10 10 N" + Environment.NewLine + "LLL";
        private static string Random => "1 5" 
                                        + Environment.NewLine + "0 0 N" + Environment.NewLine + "RRM" 
                                        + Environment.NewLine + "1 1 N" + Environment.NewLine + "LLM";
        public static IEnumerable<object[]> GetInputVerifyHeight() {
            yield return new object[] { AllOne, 1 };
            yield return new object[] { AllFive, 5 };
            yield return new object[] { AllTen, 10 };
            yield return new object[] { Random, 1 };
        }
        public static IEnumerable<object[]> GetInputVerifyWidth() {
            yield return new object[] { AllOne, 1 };
            yield return new object[] { AllFive, 5 };
            yield return new object[] { AllTen, 10 };
            yield return new object[] { Random, 5 };
        }

        public static IEnumerable<object[]> GetInputVerifyPositionX() {
            yield return new object[] { AllOne, 1 };
            yield return new object[] { AllFive, 5 };
            yield return new object[] { AllTen, 10 };
            yield return new object[] { Random, 0 };
        }

        public static IEnumerable<object[]> GetInputVerifyPositionY() {
            yield return new object[] { AllOne, 1 };
            yield return new object[] { AllFive, 5 };
            yield return new object[] { AllTen, 10 };
            yield return new object[] { Random, 0 };
        }
        
        public static IEnumerable<object[]> GetInputVerifyCommands() {
            yield return new object[] { AllOne, "LRM" };
            yield return new object[] { AllFive, "RRR" };
            yield return new object[] { AllTen, "LLL" };
            yield return new object[] { Random, "MMM" };
        }
    }
}