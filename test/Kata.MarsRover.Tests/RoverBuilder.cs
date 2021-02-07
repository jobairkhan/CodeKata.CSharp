using System;

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
            throw new NotImplementedException();
        }
    }
}