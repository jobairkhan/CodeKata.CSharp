namespace Kata.MarsRover.Tests
{
    public interface IInputParser {
        (Grid grid, Position plateau, string cmd) Parse(string inputString);
    }
}