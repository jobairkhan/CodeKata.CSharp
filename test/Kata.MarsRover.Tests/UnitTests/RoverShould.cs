using System;
using FluentAssertions;
using Kata.MarsRover.Tests.Domain;
using Kata.MarsRover.Tests.Domain.ValueObject;
using Xunit;

namespace Kata.MarsRover.Tests.UnitTests
{
    [Trait("Category", "Unit")]
    public class RoverShould {
        [Theory]
        [InlineData(Compass.N, "0 0 E")]
        [InlineData(Compass.E, "0 0 S")]
        [InlineData(Compass.S, "0 0 W")]
        [InlineData(Compass.W, "0 0 N")]
        public void Go_right_when_command_is_R(Compass compass, string expected) {
            var rover = new Rover(new Grid(5, 5),
                new Position(0, 0),
                Direction.Create(compass));
            rover.Go("R");
            rover.CurrentLocation
                .Should()
                .Be(expected);
        }

        [Theory]
        [InlineData(Compass.N, "0 0 W")]
        [InlineData(Compass.W, "0 0 S")]
        [InlineData(Compass.S, "0 0 E")]
        [InlineData(Compass.E, "0 0 N")]
        public void Go_left_when_command_is_L(Compass compass, string expected) {
            var rover = new Rover(new Grid(5, 5),
                new Position(0, 0),
                Direction.Create(compass));
            rover.Go("L");
            rover.CurrentLocation
                .Should()
                .Be(expected);
        }

        [Theory]
        [InlineData(0, 0, "1 0 E")]
        [InlineData(1, 0, "2 0 E")]
        [InlineData(4, 0, "0 0 E")]
        public void Move_position_x_given_facing_east_when_command_is_M(int x, int y, string expected) {
            var rover = new Rover(new Grid(5, 5),
                new Position(x, y),
                Direction.Create(Compass.E));
            rover.Go("M");
            rover.CurrentLocation
                .Should()
                .Be(expected);
        }

        [Theory]
        [InlineData(0, 0, "4 0 W")]
        [InlineData(1, 0, "0 0 W")]
        [InlineData(2, 0, "1 0 W")]
        public void Move_position_x_given_facing_west_when_command_is_M(int x, int y, string expected) {
            var rover = new Rover(new Grid(5, 5),
                new Position(x, y),
                Direction.Create(Compass.W));
            rover.Go("M");
            rover.CurrentLocation
                .Should()
                .Be(expected);
        }

        [Theory]
        [InlineData(0, 0, "0 1 N")]
        [InlineData(0, 1, "0 2 N")]
        [InlineData(4, 4, "4 0 N")]
        public void Move_position_y_given_facing_north_when_command_is_M(int x, int y, string expected) {
            var rover = new Rover(new Grid(5, 5),
                new Position(x, y),
                Direction.Create(Compass.N));
            rover.Go("M");
            rover.CurrentLocation
                .Should()
                .Be(expected);
        }

        [Theory]
        [InlineData(4, 4, "4 3 S")]
        [InlineData(4, 3, "4 2 S")]
        [InlineData(0, 0, "0 4 S")]
        public void Move_position_y_given_facing_south_when_command_is_M(int x, int y, string expected) {
            var rover = new Rover(new Grid(5, 5),
                new Position(x, y),
                Direction.Create(Compass.S));
            rover.Go("M");
            rover.CurrentLocation
                .Should()
                .Be(expected);
        }

        [Fact]
        public void Process_all_commands() {
            var rover = new Rover(new Grid(5, 5),
                new Position(3, 3),
                Direction.Create(Compass.N));

            rover.Go("RRMLM");

            rover.CurrentLocation
                .Should()
                .Be("4 2 E");
        }

        [Fact]
        public void Throw_error_when_invalid_input()
        {
            var rover = new Rover(new Grid(5, 5),
                new Position(3, 3),
                Direction.Create(Compass.N));

            Action act = () => rover.Go(null);

            act.Should().Throw<ArgumentNullException>("Commands cannot be null");
        }
    }
}