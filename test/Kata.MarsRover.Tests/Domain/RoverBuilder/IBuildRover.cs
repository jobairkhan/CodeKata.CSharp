using Kata.MarsRover.Tests.Domain.ValueObject;

namespace Kata.MarsRover.Tests.Domain.RoverBuilder
{
    public interface IBuildRover
    {
        IBuildRover WithGrid(Grid grid);
        IBuildRover WithPosition(Position position);
        IBuildRover WithFacing(Compass compass);
        Rover Build();
    }
}