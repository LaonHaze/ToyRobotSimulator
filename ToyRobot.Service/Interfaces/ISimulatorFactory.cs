using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Interfaces;

namespace ToyRobot.Service.Interfaces
{
    public interface ISimulatorFactory
    {
        public ISimulator Create();
    }
}
