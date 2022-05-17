using MarsRover.Entities.Concrete;
using MarsRover.Entities.Enums;


namespace MarsRover.Entities.Abstract
{
    public interface IRover
    {
        char Symbol { get; }
        bool IsLanded { get; }
        IPlateau Plateau { get; }
        Position Position { get; }



        void Move(int count);
        void TurnLeft(int count);
        void TurnRight(int count);
        void Land(IPlateau plateau, Position position);
        void Explore(IEnumerable<Command> commands);
    }
}
