using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Exceptions;
using ToyRobot.Domain.Extensions;
using ToyRobot.Domain.Interfaces;

namespace ToyRobot.Domain.Entities
{
    public readonly struct SimplePlacement : IPlacement
    {
        public int X { get; }

        public int Y { get; }

        public CompassDirection CompassDirection { get; }

        public SimplePlacement(int x, int y, CompassDirection compassDirection)
        {
            X = x;
            Y = y;
            CompassDirection = compassDirection;
        }

        public SimplePlacement MoveForward()
        {
            switch (CompassDirection)
            {
                case CompassDirection.North:
                    return new SimplePlacement(X, Y + 1, CompassDirection);
                case CompassDirection.South:
                    return new SimplePlacement(X, Y - 1, CompassDirection);
                case CompassDirection.East:
                    return new SimplePlacement(X + 1, Y, CompassDirection);
                case CompassDirection.West:
                    return new SimplePlacement(X - 1, Y, CompassDirection);
                default:
                    throw new UnexpectedCompassDirectionException("Unhandled compass direction", CompassDirection);
            }
        }

        public SimplePlacement TurnRight()
        {
            return new SimplePlacement(X ,Y , CompassDirection.Turn(1));
        }

        public SimplePlacement TurnLeft()
        {
            return new SimplePlacement(X, Y, CompassDirection.Turn(-1));
        }

        public override string ToString()
        {
            return $"{X},{Y},{CompassDirection.ToReportString()}";
        }
    }
}
