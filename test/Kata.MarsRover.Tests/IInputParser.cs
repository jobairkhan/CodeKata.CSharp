namespace Kata.MarsRover.Tests
{
    public interface IInputParser {
        (Grid, Position) Parse(string inputString);
    }
}