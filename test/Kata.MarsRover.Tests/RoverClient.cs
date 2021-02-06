using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace Kata.MarsRover.Tests {
    [Trait("Category", "Unit")]

    public class RoverClientShould {
        [Fact]
        public void Call_input_processor_Given_input_processor_added() {
            // Arrange
            var commandProcessor = new Mock<IInputParser>();
            var roverClient = new RoverClient(commandProcessor.Object);
            // Act
            roverClient.Execute("input");
            // Assert
            commandProcessor.Verify(x => x.Parse(It.IsAny<string>()));
        }
    }

    public interface IInputParser {
        void Parse(string inputString);
    }

    public class InputParser : IInputParser {
        public void Parse(string inputString)
        {
            throw new NotImplementedException();
        }
    }

    public class RoverClient {
        public RoverClient(IInputParser inputParser) {

        }

        public string Execute(string input) {
            return null;
        }
    }

}