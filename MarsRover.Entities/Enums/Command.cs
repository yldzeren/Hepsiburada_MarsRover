using Mars.Core;

namespace MarsRover.Entities.Enums
{
    public enum Command
    {
        [Information(Value = "L")]
        Left,
        [Information(Value = "R")]
        Right,
        [Information(Value = "M")]
        Move
    }
}
