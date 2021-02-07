using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using Xunit;
using static System.Int32;

namespace Kata.MarsRover.Tests {
    public class InputParser : IInputParser {
        /// <summary>
        /// Parse
        /// TODO: Refactor
        /// TODO: Add validations
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public (Grid, IEnumerable<RoverData>) Parse(string inputString) {

            var lines = inputString.Split(Environment.NewLine);
            var grid = new Grid(0, 0);
            var lst = new List<RoverData>();


            var i = 0;
            while (i < lines.Length) {
                if (i == 0) {
                    var size = lines[i].Split(" ");
                    TryParse(size[0], out var height);
                    TryParse(size[1], out var width);
                    grid = new Grid(height, width);
                    i++;
                }
                else {
                    var plateau = lines[i++].Split(" ");
                    TryParse(plateau[0], out var positionX);
                    TryParse(plateau[1], out var positionY);
                    var compass = (Compass)Enum.Parse(typeof(Compass), plateau[2]);

                    var roverData =
                        new RoverData(new Position(positionX, positionY),
                                     compass,
                                     lines[i++]);
                    lst.Add(roverData);
                }
            }

            return (grid, lst);
        }
    }

    public record Position(int X, int Y);

    public record Grid(int Height, int Width) {
        public Position NextPosition(Position coordinates, Compass direction) {
            var (x, y) = coordinates;
            if (direction.ToString() == Compass.E.ToString()) {
                x = (x + 1) % (Width);
            }
            else if (direction.ToString() == Compass.W.ToString()) {
                x = x > 0 ? x - 1 : Width - 1;
            }
            else if (direction.ToString() == Compass.N.ToString()) {
                y = (y + 1) % Height;
            }
            else if (direction.ToString() == Compass.S.ToString()) {
                y = 3;
            }
            return new Position(x, y); ;
        }
    }

    public record RoverData(Position Position, Compass Direction, string Commands);

    public class InputParserShould {
        private readonly InputParser _sut;

        public InputParserShould() {
            _sut = new InputParser();
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
            var inputParser = new InputParser();
            var (_, data) = inputParser.Parse(input);
            var (_, _, cmd) = data.First();
            cmd.Should().Be(expectedCmdString);
        }

        [Theory, MemberData(nameof(GetInputVerifyDirection))]
        public void Return_grid_with_correct_direction(string input, Compass expected) {
            var inputParser = new InputParser();
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

        public static IEnumerable<object[]> GetInputVerifyDirection() {
            yield return new object[] { AllOne, Compass.N };
            yield return new object[] { AllFive, Compass.S };
            //yield return new object[] { AllTen, "E" };
            //yield return new object[] { Random, "W" };
        }

        public static IEnumerable<object[]> GetInputVerifyCommands() {
            yield return new object[] { AllOne, "LRM" };
            yield return new object[] { AllFive, "RRR" };
            yield return new object[] { AllTen, "LLL" };
            yield return new object[] { Random, "RRM" };
        }
    }

    public enum Compass {
        /// <summary>
        /// North
        /// </summary>
        [Display(Name = "North")]
        N,
        /// <summary>
        /// East
        /// </summary>
        [Display(Name = "East")]
        E,
        /// <summary>
        /// South
        /// </summary>
        [Display(Name = "South")]
        S,
        /// <summary>
        /// West
        /// </summary>
        [Display(Name = "West")]
        W
    }
}