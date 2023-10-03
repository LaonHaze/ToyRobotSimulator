using ToyRobot.Service.Models;

namespace ToyRobot.Service.Interfaces
{
    public interface ISimulationService
    {
        SimulationResult ProcessSimulationCommand(string command);

        bool ContinueSimulation();
    }
}
