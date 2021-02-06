using System;
using FluentAssertions;
using Xunit;

namespace Kata.MarsRover.Tests {
    public class AcceptanceTest {
        /*
         * 0, 0, N, which means the rover is in the bottom left corner and facing North.
         * TODO 1: The first line of input is the upper-right coordinates of the plateau - Grid Size
         * TODO 2: Each rover has two lines of input, The first line gives the rover’s position, and the second line is a series of instructions telling the rover how to explore the plateau. 
         * TODO 3: ‘R’ makes the rover spin 90 degrees right
         * TODO 4: ‘L’ makes the rover spin 90 degrees left
         * TODO 5: ‘M’ means move forward one grid point
         * TODO 6: Output for each rover should be its final co-ordinates and heading
         */
        [Fact]
        public void Test1()
        {
            var input = @"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

";
            var sut = new RoverClient();

            var output = sut.Execute(input);

            output.Should().Be(@"1 3 N
5 1 E");
        }
    }

    public class RoverClient
    {
        public string Execute(string input)
        {
            return null;
        }
    }
}
