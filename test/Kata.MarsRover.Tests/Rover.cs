namespace Kata.MarsRover.Tests
{
    public class Rover
    {
        private readonly Grid _grid;
        private readonly Position _coordinates;
        private readonly Compass _facing;


        public Rover(Grid grid, Position coordinates, Compass facing)
        {
            _grid = grid;
            _coordinates = coordinates;
            _facing = facing;
        }

        public string CurrentLocation => $"{_coordinates.X} {_coordinates.Y} {_facing}";
    }
}