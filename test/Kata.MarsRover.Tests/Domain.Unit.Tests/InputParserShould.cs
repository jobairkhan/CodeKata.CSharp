using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Kata.MarsRover.Tests.Domain.Unit.Tests
{
    public class InputParserShould {
        private readonly InputParser.InputParser _sut;

        public InputParserShould() {
            _sut = new InputParser.InputParser();
        }

        [Theory, MemberData(nameof(GetInputVerifyHeight))]
        public void Return_grid_with_correct_height(string input, int expectedHeight) {
            var (grid, _) = _sut.Parse(input);
            grid.Height.Should().Be(expectedHeight);
        }

        [Theory, MemberData(nameof(GetInputVerifyWidth))]
        public void Return_grid_with_correct_width(string input, int expectedWidth) {
            var (grid, _) = _sut.Parse(input);
            grid.Width.Should().Be(expectedWidth);
        }

        [Theory, MemberData(nameof(GetInputVerifyPositionX))]
        public void Return_grid_with_correct_position_x(string input, int expectedX) {
            var (_, data) = _sut.Parse(input);
            var (initialPosition, _, _) = data.First();
            initialPosition.X.Should().Be(expectedX);
        }

        [Theory, MemberData(nameof(GetInputVerifyPositionY))]
        public void Return_grid_with_correct_position_y(string input, int expectedY) {
            var (_, data) = _sut.Parse(input);
            var (initialPosition, _, _) = data.First();
            initialPosition.Y.Should().Be(expectedY);
        }

        [Theory, MemberData(nameof(GetInputVerifyCommands))]
        public void Return_grid_with_correct_commands(string input, string expectedCmdString) {
            var inputParser = new InputParser.InputParser();
            var (_, data) = inputParser.Parse(input);
            var (_, _, cmd) = data.First();
            cmd.Should().Be(expectedCmdString);
        }

        [Theory, MemberData(nameof(GetInputVerifyDirection))]
        public void Return_grid_with_correct_direction(string input, Compass expected) {
            var inputParser = new InputParser.InputParser();
            var (_, data) = inputParser.Parse(input);
            var (_, direction, _) = data.First();
            direction.Should().Be(expected);
        }

        private static string AllOne => "1 1" + Environment.NewLine + "1 1 N" + Environment.NewLine + "LRM";
        private static string AllFive => "5 5" + Environment.NewLine + "5 5 S" + Environment.NewLine + "RRR";
        private static string AllTen => "10 10" + Environment.NewLine + "10 10 E" + Environment.NewLine + "LLL";

        private static string Random => "1 5"
                                        + Environment.NewLine + "0 0 W" + Environment.NewLine + "RRM"
                                        + Environment.NewLine + "1 1 N" + Environment.NewLine + "LLM";
        public static IEnumerable<object[]> GetInputVerifyHeight() {
            yield return new object[] { AllOne, 2 };
            yield return new object[] { AllFive, 6 };
            yield return new object[] { AllTen, 11 };
            yield return new object[] { Random, 2 };
        }
        public static IEnumerable<object[]> GetInputVerifyWidth() {
            yield return new object[] { AllOne, 2 };
            yield return new object[] { AllFive, 6 };
            yield return new object[] { AllTen, 11 };
            yield return new object[] { Random, 6 };
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

        public static IEnumerable<object[]> GetInputVerifyDirection() {
            yield return new object[] { AllOne, Compass.N };
            yield return new object[] { AllFive, Compass.S };
            yield return new object[] { AllTen, Compass.E };
            yield return new object[] { Random, Compass.W };
        }

        public static IEnumerable<object[]> GetInputVerifyCommands() {
            yield return new object[] { AllOne, "LRM" };
            yield return new object[] { AllFive, "RRR" };
            yield return new object[] { AllTen, "LLL" };
            yield return new object[] { Random, "RRM" };
        }
    }
}