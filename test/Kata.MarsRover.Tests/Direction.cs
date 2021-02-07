namespace Kata.MarsRover.Tests
{
    public class Direction {
        private readonly Compass _current;

        private Direction(Compass current) {
            _current = current;
        }

        public Direction GoLeft() {
            var newCompass = _current switch {
                Compass.N => Compass.W,
                Compass.W => Compass.S,
                Compass.S => Compass.E,
                Compass.E => Compass.N,
                _ => _current
            };
            return new Direction(newCompass);
        }

        public Direction GoRight() {
            var newCompass = _current switch {
                Compass.N => Compass.E,
                Compass.E => Compass.S,
                Compass.S => Compass.W,
                Compass.W => Compass.N,
                _ => _current
            };
            return new Direction(newCompass);
        }

        public static implicit operator Compass(Direction d) => d._current;

        public override string ToString()
        {
            return _current.ToString(); 
        }

        public static Direction Create(Compass compass) => new Direction(compass);
    }
}