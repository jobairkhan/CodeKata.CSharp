using System;
using FluentAssertions;
using Xunit;

namespace Kata.MarsRover.Tests
{
    public class RoverBuilder : IBuildRover {
        public IBuildRover WithGrid(Grid grid) {
            throw new NotImplementedException();
        }

        public IBuildRover WithPosition(Position position)
        {
            throw new NotImplementedException();
        }

        public IBuildRover WithFacing(Compass compass)
        {
            throw new NotImplementedException();
        }

        public Rover Build()
        {
            return null;
        }
    }

    public class RoverBuilderShould
    {
        private RoverBuilder _sut;

        public RoverBuilderShould()
        {
            _sut = new RoverBuilder();
        }

        [Fact]
        public void Not_return_nothing()
        {
            _sut.Build().Should().NotBeNull();
        }
    }
}