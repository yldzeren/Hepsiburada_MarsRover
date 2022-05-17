using MarsRover.Entities.Abstract;

namespace MarsRover.Business.Abstract
{
    internal interface IRoverBusiness
    {
        IRoverDto Create(IPlateauDto plateau, string roverPositionText);
        void Explore(IRoverDto rover, string commandText);
    }
}
