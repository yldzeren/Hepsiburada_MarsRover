using MarsRover.Business.Abstract;
using MarsRover.Business.Constants;
using MarsRover.Entities.Abstract;
using MarsRover.Entities.Concrete;
using MarsRover.Entities.Dtos;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MarsRover.Business.Concrete
{
    internal class PlateauBusiness : IPlateauBusiness
    {
        public IPlateauDto Create(string widthHeightText)
        {
            if (widthHeightText is null)
                throw new ValidationException($"Size information is null. Please try again.");

            var match = Regex.Match(widthHeightText, RegexPatterns.PlateauSize, RegexOptions.Singleline);

            if (match.Success)
                return new PlateauDto(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));

            throw new ValidationException($"{widthHeightText} is not matched.");
        }
    }
}
