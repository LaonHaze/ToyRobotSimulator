using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Exceptions;
using ToyRobot.Domain.Extensions;
using ToyRobot.Domain.Interfaces;

namespace ToyRobot.Domain.Entities
{
    public class PlacementResolver : IPlacementResolver<SimplePlacement>
    {
        public SimplePlacement MoveForward(SimplePlacement placement)
        {
            switch (placement.CompassDirection)
            {
                case CompassDirection.North:
                    return new SimplePlacement(placement.X, placement.Y + 1, placement.CompassDirection);
                case CompassDirection.South:
                    return new SimplePlacement(placement.X, placement.Y - 1, placement.CompassDirection);
                case CompassDirection.East:
                    return new SimplePlacement(placement.X + 1, placement.Y, placement.CompassDirection);
                case CompassDirection.West:
                    return new SimplePlacement(placement.X - 1, placement.Y, placement.CompassDirection);
                default:
                    throw new UnexpectedCompassDirectionException("Unhandled compass direction", placement.CompassDirection);
            }
        }

        public SimplePlacement TurnRight(SimplePlacement placement)
        {
            return new SimplePlacement(placement.X, placement.Y, placement.CompassDirection.Turn(1));
        }

        public SimplePlacement TurnLeft(SimplePlacement placement)
        {
            return new SimplePlacement(placement.X, placement.Y, placement.CompassDirection.Turn(-1));
        }
    }
}
