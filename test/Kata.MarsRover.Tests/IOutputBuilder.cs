namespace Kata.MarsRover.Tests
{
    public interface IOutputBuilder {
        void AddResult(string input);

        string Result { get; }
    }
}