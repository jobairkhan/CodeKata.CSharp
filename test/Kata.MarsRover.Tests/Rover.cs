using System;
using FluentAssertions;
using Xunit;
namespace Kata.MarsRover.Tests {
    public class Rover {
        private readonly Grid _grid;
        private Position _coordinates;
        private Direction _direction;


        public Rover(Grid grid, Position coordinates, Direction direction) {
            _grid = grid;
            _coordinates = coordinates;
            _direction = direction;
        }

        public string CurrentLocation => $"{_coordinates.X} {_coordinates.Y} {_direction}";

        public void Go(char command) {
            if (command == 'R') {
                _direction = _direction.GoRight();
            }
            else if (command == 'L') {
                _direction = _direction.GoLeft();
            }
            else if (command == 'M') {
                _coordinates = _grid.NextPosition(_coordinates, _direction);
            }
        }
    }

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
            rover.Go('R');
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
            rover.Go('L');
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
            rover.Go('M');
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
            rover.Go('M');
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
            rover.Go('M');
            rover.CurrentLocation
                .Should()
                .Be(expected);
        }
    }
}