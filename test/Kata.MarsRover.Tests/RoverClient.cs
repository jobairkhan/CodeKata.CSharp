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

            _inputParser
                .Setup(x => x.Parse(It.IsAny<string>()))
                .Returns(ParsedData());
            _roverBuilder
                .Setup(x => x.WithGrid(It.IsAny<Grid>()))
                .Returns(_roverBuilder.Object);
            _roverBuilder
                .Setup(x => x.WithPosition(It.IsAny<Position>()))
                .Returns(_roverBuilder.Object);
            _roverBuilder
                .Setup(x => x.WithFacing(It.IsAny<Compass>()))
                .Returns(_roverBuilder.Object);
            _roverBuilder
                .Setup(x => x.Build())
                .Returns(GetRover());
        }

        private static Rover GetRover()
        {
            var rover = new Rover(new Grid(10, 10),
                new Position(0, 0),
                Direction.Create());
            return rover;
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
            _inputParser
                .Setup(x => x.Parse(It.IsAny<string>()))
                .Returns(ParsedData());
            _sut.Execute("input");
            _outputBuilder
                .Verify(x => x.AddResult(It.IsAny<string>()),
                Times.Once);
        }

        [Theory]
        [InlineData("output")]
        [InlineData("result")]
        public void Return_output_processor_result(string expected) {
            _outputBuilder
                .Setup(x => x.Result).Returns(expected);

            var actual = _sut.Execute("input");
            actual.Should().Be(expected);
        }


        [Fact]
        public void Build_rover_with_grid()
        {
            _sut.Execute("input");
            _roverBuilder.Verify(x => x.WithGrid(It.IsAny<Grid>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Build_rover_with_position()
        {                               
            _sut.Execute("input");
            _roverBuilder.Verify(x => x.WithPosition(It.IsAny<Position>()), Times.Once);
        }

        [Fact]
        public void Build_rover_with_compass()
        {
            _sut.Execute("input");
            _roverBuilder.Verify(x => x.WithFacing(It.IsAny<Compass>()), Times.Once);
        }

        [Fact]
        public void Build_rover()
        {
            _sut.Execute("input");
            _roverBuilder.Verify(x => x.Build(), Times.Once);
        }

        [Fact, Trait("Category", "Acceptance")]
        public void Pass_command_to_Rovers() {

            _inputParser.Setup(x => x.Parse(It.IsAny<string>()))
                .Returns(ParsedData("RMMM"));

            var roverClient = new RoverClient(_inputParser.Object, new RoverBuilder(), new StringOutputBuilder());

            var output = roverClient.Execute("ignoreMe");

            output.Should().Be(@"3 0 E");
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
                var d = _roverBuilder
                    .WithGrid(grid);
                var g = d.WithGrid(grid);
                var rover = _roverBuilder
                    .WithGrid(grid)
                    .WithPosition(roverData.Position)
                    .WithFacing(roverData.Direction)
                    .Build();

                rover.Go(roverData.Commands);
                _outputBuilder.AddResult(rover.CurrentLocation);
            }
            
            return _outputBuilder.Result;
        }
    }

}