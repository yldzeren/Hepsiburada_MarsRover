using MarsRover.Entities.Abstract;

namespace MarsRover.Business.Abstract
{
    internal interface IPlateauBusiness
    {
        IPlateauDto Create(string widthHeightText);
    }
}
