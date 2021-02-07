using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace Kata.MarsRover.Tests {
    [Trait("Category", "Unit")]

    public class RoverClientShould {
        private Mock<IInputParser> _inputParser;
        private Mock<IOutputBuilder> _outputBuilder;
        private Mock<IBuildRover> _roverBuilder;
        private RoverClient _sut;

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
        public void Should_build_rover_with_grid()
        {
            _inputParser.Setup(x => x.Parse(It.IsAny<string>()))
                .Returns((new Grid(5, 5), new []{ (new Position(0,0), "RRR")}));
            _sut.Execute("input");
            _roverBuilder.Verify(x => x.WithGrid(It.IsAny<Grid>()), Times.Once);
        }

    }

    public interface IBuildRover
    {
        IBuildRover WithGrid(Grid grid);
    }

    public class RoverBuilder : IBuildRover {
        public IBuildRover WithGrid(Grid grid) {
            throw new NotImplementedException();
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
            foreach (var (pos, cmd) in lst)
            {
                _roverBuilder.WithGrid(grid);
            }
            _outputBuilder.AddResult("");
            return _outputBuilder.Result;
        }
    }

}