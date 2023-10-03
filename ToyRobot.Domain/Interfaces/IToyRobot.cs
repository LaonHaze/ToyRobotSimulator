using System.Runtime.CompilerServices;

namespace ToyRobot.Domain.Interfaces
{
    public interface IToyRobot<TTuple, TEnum>
        where TTuple : ITuple
        where TEnum : struct, IConvertible
    {
        void Place(ITable<TTuple> table, TTuple position, TEnum orientation);

        void MoveForward();

        void TurnRight();

        void TurnLeft();

        string Report();
    }
}
