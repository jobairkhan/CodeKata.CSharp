using Kata.MarsRover.Tests.Domain.ValueObject;

namespace Kata.MarsRover.Tests.Domain.RoverBuilder
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
}