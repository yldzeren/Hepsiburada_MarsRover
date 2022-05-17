

using MarsRover.Entities.Abstract;

namespace MarsRover.Entities.Concrete
{
    public class Position : ICloneable
    {
        public Position(int x, int y, IDirection routeKey)
        {
            X = x; Y = y; Direction = routeKey;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public IDirection Direction { get; set; }
        public object Clone() => new Position(X, Y, Direction);
        public override string ToString() => $"{X} {Y} {Direction.Key}";
    }
}
