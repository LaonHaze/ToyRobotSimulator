using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Exceptions;
using ToyRobot.Domain.Extensions;
using ToyRobot.Domain.Interfaces;

namespace ToyRobot.Domain.Entities
{
    public class ToyRobot : IToyRobot<(int X, int Y), CompassDirection>
    {
        public (int X, int Y) Coords { get; private set; }

        public CompassDirection Orientation { get; private set; }

        public ITable<(int X, int Y)>? Table { get; private set; }

        public void Place(ITable<(int X, int Y)> table, (int X, int Y) position, CompassDirection orientation)
        {
            if (table.IsValidPosition(position))
            {
                Table = table;
                Coords = position;
                Orientation = orientation;
            }
        }

        public void MoveForward()
        {
            if (Table != null)
            {
                (int X, int Y) newCoords;
                switch (Orientation)
                {
                    case CompassDirection.North:
                        newCoords = (Coords.X, Coords.Y + 1);
                        break;
                    case CompassDirection.South:
                        newCoords = (Coords.X, Coords.Y - 1);
                        break;
                    case CompassDirection.East:
                        newCoords = (Coords.X + 1, Coords.Y);
                        break;
                    case CompassDirection.West:
                        newCoords = (Coords.X - 1, Coords.Y);
                        break;
                    default:
                        throw new UnexpectedCompassDirectionException("Unhandled compass direction", Orientation);
                }

                if (Table.IsValidPosition(newCoords))
                {
                    Coords = newCoords;
                }
            }
        }

        public void TurnRight()
        {
            if (Table != null)
            {
                Orientation = Orientation.Turn(1);
            }
        }

        public void TurnLeft()
        {
            if (Table != null)
            {
                Orientation = Orientation.Turn(-1);
            }
        }

        public string Report()
        {
            return Table != null ? Coords.X + "," + Coords.Y + "," + Orientation.ToReportString() : string.Empty;
        }
    }
}