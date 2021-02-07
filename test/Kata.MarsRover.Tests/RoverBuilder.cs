using System;
using FluentAssertions;
using Xunit;

namespace Kata.MarsRover.Tests
{
    public class RoverBuilder : IBuildRover {
        private readonly Grid _grid;
        private readonly Position _position;
        private readonly Compass _compass;

        public RoverBuilder()
        {
            _grid = new Grid(0, 0);
        }

        private RoverBuilder(Grid grid, Position position, Compass compass)
        {
            _grid = grid;
            _position = position;
            _compass = compass;
        }

        public IBuildRover WithGrid(Grid grid)
        {
            return new RoverBuilder(grid, _position, _compass);
        }

        public IBuildRover WithPosition(Position position)
        {
            return new RoverBuilder(_grid, position, _compass);
        }

        public IBuildRover WithFacing(Compass compass) {
            return new RoverBuilder(_grid, _position, compass);
        }

        public Rover Build()
        {
            return new Rover(_grid, _position, Direction.Create(_compass));
        }
    }

    public class RoverBuilderShould
    {
        private readonly RoverBuilder _sut;
        private readonly Rover _rover;

        public RoverBuilderShould()
        {
            _sut = new RoverBuilder();
            _rover = _sut
                .WithGrid(new Grid(10, 10))
                .WithFacing(Compass.N)
                .WithPosition(new Position(1, 1))
                .Build();
        }

        [Fact]
        public void Not_return_nothing()
        {
            _rover              
                .Should()
                .NotBeNull();
        }
    
        [Fact]
        public void Set_initial_location()
        {
            _rover
                .CurrentLocation
                .Should()
                .Be("1 1 N");
        }
    }
}