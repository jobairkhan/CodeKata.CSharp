using System.Collections.Generic;

namespace Kata.MarsRover.Tests
{
    public interface IInputParser {
        (Grid grid, IEnumerable<RoverData> data) Parse(string inputString);
    }
}