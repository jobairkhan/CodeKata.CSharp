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
            if(_facing == Compass.N) _facing = Compass.E;
            else
            {
                _facing = Compass.S;
            }
        }
    }

    public class RoverShould
    {
        [Fact]
        public void Go_right_when_command_R()
        {
            var rover = new Rover(new Grid(5, 5), new Position(0, 0), Compass.N);
            rover.Go("R");
            rover.CurrentLocation
                .Should()
                .Be("0 0 E");
        }

        [Fact]
        public void Go_right_when_command_R_and_facing_E()
        {
            var rover = new Rover(new Grid(5, 5), 
                                 new Position(0, 0), 
                                 Compass.E);
            rover.Go("R");
            rover.CurrentLocation
                .Should()
                .Be("0 0 S");
        }

        [Fact]
        public void Go_right_when_command_R_and_facing_S()
        {
            var rover = new Rover(new Grid(5, 5), 
                                 new Position(0, 0), 
                                 Compass.S);
            rover.Go("R");
            rover.CurrentLocation
                .Should()
                .Be("0 0 W");
        }
    }
}