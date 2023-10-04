using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Domain.Entities;

namespace ToyRobot.Domain.Interfaces
{
    public interface IPlacementResolver<T> where T : struct
    {
        T MoveForward(T placement);

        T TurnRight(T placement);

        T TurnLeft(T placement);
    }
}
