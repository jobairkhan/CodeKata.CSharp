namespace Kata.MarsRover.Tests
{
    public interface IBuildRover
    {
        IBuildRover WithGrid(Grid grid);
        IBuildRover WithPosition(Position position);
        IBuildRover WithFacing(Compass compass);
        Rover Build();
    }
}