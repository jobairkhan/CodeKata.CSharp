namespace Kata.MarsRover.Tests.Domain.OutputBuilder
{
    public interface IOutputBuilder {
        void AddResult(string result);

        string Result { get; }
    }
}