namespace Kata.MarsRover.Tests
{
    public interface IOutputBuilder {
        void AddResult(string result);

        string Result { get; }
    }
}