using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Exceptions;
using ToyRobot.Domain.Extensions;

namespace ToyRobot.Domain.Entities
{
    public readonly struct SimplePlacement
    {
        public int X { get; init; }

        public int Y { get; init; }

        public CompassDirection CompassDirection { get; init; }

        public SimplePlacement(int x, int y, CompassDirection compassDirection)
        {
            X = x;
            Y = y;
            CompassDirection = compassDirection;
        }

        public override string ToString()
        {
            return $"{X},{Y},{CompassDirection.ToReportString()}";
        }
    }
}
