using System;

namespace Kata.MarsRover.Tests.Domain.ValueObject
{
    public record Grid(int Height, int Width) {
        public Position NextPosition(Position coordinates, Compass direction) {
            var (x, y) = coordinates;
            switch (direction)
            {
                case Compass.N:
                    y = (y + 1) % Height;
                    break;
                case Compass.E:
                    x = (x + 1) % (Width);
                    break;
                case Compass.S:
                    y = y > 0 ? y - 1 : Height - 1;
                    break;
                case Compass.W:
                    x = x > 0 ? x - 1 : Width - 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
            
            return new Position(x, y); ;
        }
    }
}