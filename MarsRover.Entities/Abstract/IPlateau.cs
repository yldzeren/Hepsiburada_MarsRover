using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Entities.Abstract
{
    public interface IPlateau
    {
        int Width { get; }
        int Heigth { get; }
        ICollection<IRover> Rovers { get; }


        void AddRover(IRover rover);
    }
}
