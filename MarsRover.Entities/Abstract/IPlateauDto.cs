using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Entities.Abstract
{
    public interface IPlateauDto : IPlateau
    {
        new ICollection<IRover> Rovers { get; }

    }
}
