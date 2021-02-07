using FluentAssertions;
using Kata.MarsRover.Tests.Domain.ValueObject;
using Xunit;

namespace Kata.MarsRover.Tests.Domain.Unit.Tests
{
    public class RoverBuilderShould
    {
        private readonly RoverBuilder.RoverBuilder _sut;
        private readonly Rover _rover;

        public RoverBuilderShould()
        {
            _sut = new RoverBuilder.RoverBuilder();
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