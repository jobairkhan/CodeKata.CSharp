using System;
using Kata.MarsRover.Tests.Domain.ValueObject;

namespace Kata.MarsRover.Tests.Domain {
    public class Rover {
        private readonly Grid _grid;
        private Position _coordinates;
        private Direction _direction;


        public Rover(Grid grid, Position coordinates, Direction direction) {
            _grid = grid;
            _coordinates = coordinates;
            _direction = direction;
        }

        public string CurrentLocation => $"{_coordinates.X} {_coordinates.Y} {_direction}";

        /// <summary>
        /// Execute commands 
        /// TODO: Add Validations
        /// </summary>
        /// <param name="commands"></param>
        public void Go(string commands) {
            if (string.IsNullOrWhiteSpace(commands))
            {
                throw new ArgumentException(nameof(commands));
            }

            foreach (var command in commands) {
                switch (command)
                {
                    case 'R':
                        _direction = _direction.GoRight();
                        break;
                    case 'L':
                        _direction = _direction.GoLeft();
                        break;
                    case 'M':
                        _coordinates = _grid.NextPosition(_coordinates, _direction);
                        break;
                }
            }
        }
    }
}