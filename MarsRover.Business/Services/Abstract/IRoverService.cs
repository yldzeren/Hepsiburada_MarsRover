using MarsRover.Core.Utilities.Results;
using MarsRover.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Services.Abstract
{
    public interface IRoverService
    {
        TransactionResult<IRoverDto> Create(IPlateauDto plateau, string roverPositionText);
        TransactionResult Explore(IRoverDto rover, string commandText);
    }
}
