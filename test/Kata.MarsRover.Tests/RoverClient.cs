using FluentAssertions;
using Moq;
using Xunit;

namespace Kata.MarsRover.Tests {
    [Trait("Category", "Unit")]

    public class RoverClientShould {
        [Fact]
        public void Call_input_processor_Given_input_processor_added() {
            // Arrange
            var inputParser = new Mock<IInputParser>();
            var outputBuilder = new Mock<IOutputBuilder>();
            var roverClient = new RoverClient(inputParser.Object, outputBuilder.Object);
            // Act
            roverClient.Execute("input");
            // Assert
            inputParser.Verify(x => x.Parse("input"));
        }

        [Fact]
        public void Call_output_processor_Given_output_processor_added() {
            // Arrange
            var inputProcessor = new Mock<IInputParser>();
            var outputBuilder = new Mock<IOutputBuilder>();
            var roverClient = new RoverClient(inputProcessor.Object, outputBuilder.Object);
            // Act
            roverClient.Execute("input");
            // Assert
            outputBuilder.Verify(x => x.AddResult(It.IsAny<string>()));
        }
    }

    public interface IOutputBuilder {
        void AddResult(string input);
    }

    public class RoverClient {
        private readonly IInputParser _inputParser;
        private readonly IOutputBuilder _outputBuilder;

        public RoverClient(IInputParser inputParser, IOutputBuilder outputBuilder)
        {
            _inputParser = inputParser;
            _outputBuilder = outputBuilder;
        }

        public string Execute(string input) {
            _inputParser.Parse(input);
            
            return null;
        }
    }

}