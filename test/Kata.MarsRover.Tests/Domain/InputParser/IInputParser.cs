using System.Collections.Generic;
using Kata.MarsRover.Tests.Domain.ValueObject;

namespace Kata.MarsRover.Tests.Domain.InputParser
{
    public interface IInputParser {
        (Grid grid, IEnumerable<RoverData> data) Parse(string inputString);
    }
}