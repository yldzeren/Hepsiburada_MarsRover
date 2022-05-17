using MarsRover.Entities.Abstract;

namespace MarsRover.Entities.Concrete
{
    internal class Direction : IDirection
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public int Angle { get; set; }
        public int AxisY { get; set; }
        public int AxisX { get; set; }
    }
}
