using FluentAssertions;
using Moq;
using Xunit;

namespace Kata.MarsRover.Tests {
    [Trait("Category", "Unit")]

    public class RoverClientShould {
        private readonly Mock<IInputParser> _inputParser;
        private readonly Mock<IOutputBuilder> _outputBuilder;
        private readonly Mock<IBuildRover> _roverBuilder;
        private readonly RoverClient _sut;

        public RoverClientShould() {
            _inputParser = new Mock<IInputParser>();
            _roverBuilder = new Mock<IBuildRover>();
            _outputBuilder = new Mock<IOutputBuilder>();

            _sut = new RoverClient(_inputParser.Object, _roverBuilder.Object, _outputBuilder.Object);
        }

        [Fact]
        public void Call_input_processor_Given_input_processor_added() {
            _sut.Execute("input");
            _inputParser
                .Verify(x => x.Parse("input"),
                    Times.Once);
        }

        [Fact]
        public void Call_output_processor_Given_output_processor_added() {
            _sut.Execute("input");
            _outputBuilder
                .Verify(x => x.AddResult(It.IsAny<string>()),
                Times.Once);
        }

        [Theory]
        [InlineData("output")]
        [InlineData("result")]
        public void Return_output_processor_result(string expected) {
            _outputBuilder.Setup(x => x.Result).Returns(expected);
            var actual = _sut.Execute("input");
            actual.Should().Be(expected);
        }


        [Fact]
        public void Build_rover_with_grid()
        {
            _inputParser.Setup(x => x.Parse(It.IsAny<string>()))
                .Returns(ParsedData());
            _sut.Execute("input");
            _roverBuilder.Verify(x => x.WithGrid(It.IsAny<Grid>()), Times.Once);
        }

        [Fact]
        public void Build_rover_with_position()
        {
            _inputParser.Setup(x => x.Parse(It.IsAny<string>()))
                .Returns(ParsedData());
            _sut.Execute("input");
            _roverBuilder.Verify(x => x.WithPosition(It.IsAny<Position>()), Times.Once);
        }

        [Fact]
        public void Build_rover_with_compass()
        {
            _inputParser.Setup(x => x.Parse(It.IsAny<string>()))
                .Returns(ParsedData());
            _sut.Execute("input");
            _roverBuilder.Verify(x => x.WithFacing(It.IsAny<Compass>()), Times.Once);
        }

        [Fact]
        public void Build_rover()
        {
            _inputParser.Setup(x => x.Parse(It.IsAny<string>()))
                .Returns(ParsedData());
            _sut.Execute("input");
            _roverBuilder.Verify(x => x.Build(), Times.Once);
        }

        private static (Grid, RoverData[]) ParsedData(string commands = "RRR")
        {
            return (new Grid(5, 5), 
                new []
                {
                    new RoverData(
                        new Position(0,0), 
                        Compass.N,
                        commands)
                });
        }
    }

    public class RoverClient {
        private readonly IInputParser _inputParser;
        private readonly IBuildRover _roverBuilder;
        private readonly IOutputBuilder _outputBuilder;

        public RoverClient(IInputParser inputParser, IBuildRover roverBuilder, IOutputBuilder outputBuilder) {
            _inputParser = inputParser;
            _roverBuilder = roverBuilder;
            _outputBuilder = outputBuilder;
        }

        public string Execute(string input) {
            var (grid, lst) = _inputParser.Parse(input);
            foreach (var roverData in lst)
            {
                _roverBuilder.WithGrid(grid);
                _roverBuilder.WithPosition(roverData.Position);
                _roverBuilder.WithFacing(roverData.Direction);
                var rover = _roverBuilder.Build();
            }
            _outputBuilder.AddResult("");
            return _outputBuilder.Result;
        }
    }

}