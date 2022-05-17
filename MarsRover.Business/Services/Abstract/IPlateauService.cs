using MarsRover.Core.Utilities.Results;
using MarsRover.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Services.Abstract
{
    public interface IPlateauService
    {
        TransactionResult<IPlateauDto> Create(string widthHeightText);
        TransactionResult<string> DisplayText(IPlateauDto plateau);
    }
}
