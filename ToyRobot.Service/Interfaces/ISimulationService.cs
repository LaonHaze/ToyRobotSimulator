using ToyRobot.Service.Models;

namespace ToyRobot.Service.Interfaces
{
    public interface ISimulationService
    {
        /// <summary>
        /// Processes command
        /// </summary>
        /// <param name="command">Single line of command for simulation to process</param>
        /// <returns>Simulation result</returns>
        SimulationResult ProcessSimulationCommand(string command);

        /// <summary>
        /// Method to check simulator's EndOfSimulation flag
        /// </summary>
        /// <returns>simulator's EndOfSimulation flag</returns>
        bool ContinueSimulation();

        /// <summary>
        /// Method to set simulator's EndOfSimulation flag to true
        /// </summary>
        void EndSimulation();
    }
}
