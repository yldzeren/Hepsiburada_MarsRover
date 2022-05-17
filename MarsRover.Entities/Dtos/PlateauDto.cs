using MarsRover.Entities.Abstract;
using MarsRover.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Entities.Dtos
{
    public class PlateauDto : Plateau, IPlateauDto
    {
        public PlateauDto(int widht, int heigth) : base(widht, heigth)
        {
        }
    }
}
