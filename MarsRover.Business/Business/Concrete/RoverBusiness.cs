using Mars.Core;
using MarsRover.Business.Abstract;
using MarsRover.Business.Constants;
using MarsRover.Entities.Abstract;
using MarsRover.Entities.Concrete;
using MarsRover.Entities.Dtos;
using MarsRover.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MarsRover.Business.Concrete
{
    internal class RoverBusiness : IRoverBusiness
    {
        public IRoverDto Create(IPlateauDto plateau, string roverPositionText)
        {
            if (plateau is null)
                throw new ValidationException("Plateau is null. Please try again.");
            if (roverPositionText is null)
                throw new ValidationException("Position is null. Please try again.");

            var roverMatch = Regex.Match(roverPositionText, RegexPatterns.RoverPosition, RegexOptions.Singleline);

            if (!roverMatch.Success)
                throw new ValidationException($"{roverPositionText} is not matched.");

            var rover = new RoverDto();
            rover.Land(plateau, new Position(int.Parse(roverMatch.Groups[1].Value), int.Parse(roverMatch.Groups[2].Value), Directions.Items.FirstOrDefault(a => a.Key.Equals(roverMatch.Groups[3].Value.ToUpper()))));

            return rover;
        }
        public void Explore(IRoverDto rover, string commandText)
        {
            if (rover is null)
                throw new ValidationException("Rover is null. Please try again.");
            if (commandText is null)
                throw new ValidationException("Command is null. Please try again.");

            var commandMatch = Regex.Match(commandText, RegexPatterns.Command, RegexOptions.Singleline);

            if (!commandMatch.Success || !commandMatch.Groups[1].Value.Equals(commandText))
                throw new ValidationException($"{commandText} is not matched.");

            var commands = commandText.Select(s => EnumExtensions.GetMemberByValue<Command>(s.ToString().ToUpper()));
            rover.Explore(commands);
        }
    }

}
