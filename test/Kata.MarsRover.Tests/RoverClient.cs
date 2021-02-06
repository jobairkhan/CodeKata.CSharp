using Moq;
using Xunit;

namespace Kata.MarsRover.Tests {
    [Trait("Category", "Unit")]

    public class RoverClientShould {
        private Mock<IInputParser> _inputParser;
        private Mock<IOutputBuilder> _outputBuilder;
        private RoverClient _sut;

        public RoverClientShould()
        {
            _inputParser = new Mock<IInputParser>();
            _outputBuilder = new Mock<IOutputBuilder>();
            _sut = new RoverClient(_inputParser.Object, _outputBuilder.Object);
            _sut.Execute("input");
        }

        [Fact]
        public void Call_input_processor_Given_input_processor_added() {
            _inputParser.Verify(x => x.Parse("input"));
        }

        [Fact]
        public void Call_output_processor_Given_output_processor_added() {
            _outputBuilder.Verify(x => x.AddResult(It.IsAny<string>()));
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
            _outputBuilder.AddResult("");
            return null;
        }
    }

}