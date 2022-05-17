using MarsRover.Entities.Abstract;
using MarsRover.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Entities.Concrete
{
    public class Rover : IRover
    {
        public char Symbol => '°';
        public bool IsLanded { get; private set; }

        public Position Position { get; private set; }
        public IPlateau Plateau { get; private set; }



        public void Land(IPlateau plateau, Position position)
        {

            #region Validations
            if (plateau is null)
                throw new ValidationException("Plateau is not null");
            if (position is null)
                throw new ValidationException("Plateau is not null");
            if (plateau.Width < position.X)
                throw new ValidationException("Plateau X dimention is not lass than positon X");
            if (plateau.Heigth < position.Y)
                throw new ValidationException("Plateau Y dimention is not lass than positon Y");
            if (position.X < 0)
                throw new ValidationException("Position X is not less than 0");
            if (position.Y < 0)
                throw new ValidationException("Position Y is not less than 0");
            #endregion

            Plateau = plateau;
            Plateau.AddRover(this);
            Position = position;
            IsLanded = true;
        }

        public void Explore(IEnumerable<Command> commands)
        {

            #region Validations
            if (commands is null)
                throw new ValidationException("Commands is not null");
            if (!commands.Any())
                throw new ValidationException("Commands is not empty");
            if (!IsLanded)
                throw new ValidationException("This rover is not landing");
            #endregion

            Position currentPosition = (Position)Position.Clone();

            try
            {
                foreach (var command in commands)
                {

                    switch (command)
                    {
                        case Command.Left:
                            TurnLeft(1);
                            break;
                        case Command.Right:
                            TurnRight(1);
                            break;
                        case Command.Move:
                            Move(1);
                            break;
                    }
                }
            }
            catch (ValidationException ve)
            {
                Position = currentPosition;
                throw ve;
            }
        }

        public void Move(int count)
        {
            if (Plateau.Width < Position.X + (count * Position.Direction.AxisX))
                throw new ValidationException("Rover position X is not less than plateau width");
            if (Position.X + (count * Position.Direction.AxisX) < 0)
                throw new ValidationException("Rover position X is not less than 0");
            if (Plateau.Heigth < Position.Y + (count * Position.Direction.AxisY))
                throw new ValidationException("Rover position Y is not less than plateau heigth");
            if (Position.Y + (count * Position.Direction.AxisY) < 0)
                throw new ValidationException("Rover Y is not less than 0");

            Position.X += count * Position.Direction.AxisX;
            Position.Y += count * Position.Direction.AxisY;
        }

        public void TurnLeft(int count)
        {
            Turn(-90 * count);
        }

        public void TurnRight(int count)
        {
            Turn(90 * count);
        }

        private void Turn(int degree)
        {
            int angle = ((360 + (Position.Direction.Angle + degree)) % 360);

            var newDirection = Directions.Items.FirstOrDefault(a => a.Angle.Equals(angle));
            if (newDirection is null)
                throw new ValidationException("Its Not right angle");

            Position.Direction = newDirection;
        }
    }
}
