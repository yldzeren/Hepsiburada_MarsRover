using MarsRover.Entities.Abstract;

namespace MarsRover.Entities.Concrete
{
    public static class Directions
    {
        public static IDirection North => new Direction { Key = "N", Name = "North", Angle = 0, AxisX = 0, AxisY = +1 };
        public static IDirection East => new Direction { Key = "E", Name = "East", Angle = 90, AxisX = +1, AxisY = 0 };
        public static IDirection South => new Direction { Key = "S", Name = "South", Angle = 180, AxisX = 0, AxisY = -1 };
        public static IDirection West => new Direction { Key = "W", Name = "West", Angle = 270, AxisX = -1, AxisY = 0 };
        public static IReadOnlyCollection<IDirection> Items => new HashSet<IDirection> { North, East, South, West };
    }
}
