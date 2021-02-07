using Kata.MarsRover.Tests.Domain.InputParser;
using Kata.MarsRover.Tests.Domain.OutputBuilder;
using Kata.MarsRover.Tests.Domain.RoverBuilder;

namespace Kata.MarsRover.Tests.Domain {
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