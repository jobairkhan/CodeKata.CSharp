using System;
using FluentAssertions;
using Kata.MarsRover.Tests.Domain;
using Kata.MarsRover.Tests.Domain.InputParser;
using Kata.MarsRover.Tests.Domain.OutputBuilder;
using Kata.MarsRover.Tests.Domain.RoverBuilder;
using Xunit;

namespace Kata.MarsRover.Tests {
    [Trait("Category", "Unit")]
    public class MarsRoverKataAcceptanceTest {
        /*
         * 0, 0, N, which means the rover is in the bottom left corner and facing North.
         * TODO [X]: InputParser should return grid initialPosition commands
         * TODO [X]: RoverClient should ask rover to follow all command
         * TODO [X]: The first line of input is the upper-right coordinates of the plateau - Grid Size
         * TODO [X]: Each rover has two lines of input, The first line gives the rover’s position, and the second line is a series of instructions telling the rover how to explore the plateau. 
         * TODO [X]: ‘R’ makes the rover spin 90 degrees right
         * TODO [X]: ‘L’ makes the rover spin 90 degrees left
         * TODO [X]: ‘M’ means move forward one grid point
         * TODO [X]: Output for each rover should be its final co-ordinates and heading
         * TODO [X]: RoverBuilder should create rover with all values
         * TODO [ ]: Validations
         * TODO [ ]: Apply State design pattern
         */
        [Fact()]
        public void FinalCoordinatesAndHeading()
        {
            var input = @"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

";
            var sut = new RoverClient(new InputParser(), new RoverBuilder() , new StringOutputBuilder());

            var output = sut.Execute(input);

            output.Should().Be(@"1 3 N
5 1 E");
        }
    }
}
