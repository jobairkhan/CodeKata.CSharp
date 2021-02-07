using System;
using System.Collections.Generic;
using Kata.MarsRover.Tests.Domain.ValueObject;
using static System.Int32;

namespace Kata.MarsRover.Tests.Domain.InputParser {
    public class InputParser : IInputParser {
        /// <summary>
        /// Parse
        /// TODO: Refactor
        /// TODO: Add validations
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public (Grid, IEnumerable<RoverData>) Parse(string inputString) {

            var lines = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var grid = new Grid(0, 0);
            var lst = new List<RoverData>();


            var i = 0;
            while (i < lines.Length) {
                if (i == 0) {
                    var size = lines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    TryParse(size[0], out var height);
                    TryParse(size[1], out var width);
                    grid = new Grid(height + 1, width + 1);
                    i++;
                }
                else {
                    var plateau = lines[i].Split(" ");
                    TryParse(plateau[0], out var positionX);
                    TryParse(plateau[1], out var positionY);
                    var compass = (Compass)Enum.Parse(typeof(Compass), plateau[2]);
                    i++;
                    var roverData =
                        new RoverData(new Position(positionX, positionY),
                                     compass,
                                     lines[i]);
                    i++;
                    lst.Add(roverData);
                }
            }

            return (grid, lst);
        }
    }
}