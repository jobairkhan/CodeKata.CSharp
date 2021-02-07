using System.Collections.Generic;

namespace Kata.MarsRover.Tests
{
    public interface IInputParser {
        (Grid grid, IEnumerable<(Position plateau, string cmd)>) Parse(string inputString);
    }
}