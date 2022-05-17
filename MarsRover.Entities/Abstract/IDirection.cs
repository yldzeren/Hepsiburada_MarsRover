namespace MarsRover.Entities.Abstract
{
    public interface IDirection
    {
        string Name { get; }
        string Key { get; }
        int Angle { get; }
        int AxisY { get; }
        int AxisX { get; }
    }
}
