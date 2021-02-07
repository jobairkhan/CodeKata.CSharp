using System;
using FluentAssertions;
using Xunit;
namespace Kata.MarsRover.Tests
{
    public class Rover
    {
        private readonly Grid _grid;
        private Position _coordinates;
        private Compass _facing;


        public Rover(Grid grid, Position coordinates, Compass facing)
        {
            _grid = grid;
            _coordinates = coordinates;
            _facing = facing;
        }

        public string CurrentLocation => $"{_coordinates.X} {_coordinates.Y} {_facing}";

        public void Go(string command)
        {
            _facing = _facing switch
            {
                Compass.N => Compass.E,
                Compass.S => Compass.W,
                Compass.E => Compass.S,
                _ => _facing
            };
        }
    }

    public class RoverShould
    {
        [Theory]
        [InlineData(Compass.N, "0 0 E")]
        [InlineData(Compass.E, "0 0 S")]
        [InlineData(Compass.S, "0 0 W")]
        public void Go_right_when_command_R(Compass init, string expected)
        {
            var rover = new Rover(new Grid(5, 5), 
                                  new Position(0, 0), 
                                  init);
            rover.Go("R");
            rover.CurrentLocation
                .Should()
                .Be(expected);
        }
    }
}