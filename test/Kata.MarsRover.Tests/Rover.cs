using System;
using FluentAssertions;
using Xunit;
namespace Kata.MarsRover.Tests {
    public class Rover {
        private readonly Grid _grid;
        private Position _coordinates;
        private Direction _direction;


        public Rover(Grid grid, Position coordinates, Compass facing) {
            _grid = grid;
            _coordinates = coordinates;
            _direction = new Direction(facing);
        }

        public string CurrentLocation => $"{_coordinates.X} {_coordinates.Y} {_direction}";

        public void Go(char command) {
            if (command == 'R')
            {
                _direction = _direction.GoRight();
            }
            else if (command == 'L')
            {
                _direction = _direction.GoLeft();
            }
        }
    }

    public class Direction {
        private readonly Compass _current;

        public Direction(Compass current) {
            _current = current;
        }

        public Direction GoLeft() {
            var newCompass = _current switch {
                Compass.N => Compass.W,
                Compass.W => Compass.S,
                Compass.S => Compass.E,
                Compass.E => Compass.N,
                _ => _current
            };
            return new Direction(newCompass);
        }

        public Direction GoRight() {
            var newCompass = _current switch {
                Compass.N => Compass.E,
                Compass.E => Compass.S,
                Compass.S => Compass.W,
                Compass.W => Compass.N,
                _ => _current
            };
            return new Direction(newCompass);
        }

        public override string ToString()
        {
            return _current.ToString(); 
        }
    }

    public class RoverShould {
        [Theory]
        [InlineData(Compass.N, "0 0 E")]
        [InlineData(Compass.E, "0 0 S")]
        [InlineData(Compass.S, "0 0 W")]
        [InlineData(Compass.W, "0 0 N")]
        public void Go_right_when_command_is_R(Compass init, string expected) {
            var rover = new Rover(new Grid(5, 5),
                                  new Position(0, 0),
                                  init);
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
        public void Go_left_when_command_is_L(Compass init, string expected) {
            var rover = new Rover(new Grid(5, 5),
                                  new Position(0, 0),
                                  init);
            rover.Go('L');
            rover.CurrentLocation
                .Should()
                .Be(expected);
        }
    }
}