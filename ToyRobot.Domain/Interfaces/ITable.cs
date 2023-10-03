using System.Runtime.CompilerServices;

namespace ToyRobot.Domain.Interfaces
{
    public interface ITable<TTuple> where TTuple : ITuple
    {
        bool IsValidPosition(TTuple position);
    }
}
