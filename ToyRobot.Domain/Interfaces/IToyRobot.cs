using System.Runtime.CompilerServices;
using ToyRobot.Domain.Enums;

namespace ToyRobot.Domain.Interfaces
{
    public interface IToyRobot<TTuple, TEnum>
        where TTuple : ITuple
        where TEnum : struct, IConvertible
    {
        public (int X, int Y) Coords { get; }

        public CompassDirection Orientation { get; }

        public ITable<(int X, int Y)>? Table { get; }

        void Place(ITable<TTuple> table, TTuple position, TEnum orientation);

        void MoveForward();

        void TurnRight();

        void TurnLeft();

        string Report();
    }
}
