using ToyRobot.Domain.Enums;

namespace ToyRobot.Domain.Interfaces
{
    public interface ISimulator
    {
        /// <summary>
        /// If this flag is set to true, simulation will end
        /// </summary>
        bool EndOfSimulation { get; }

        /// <summary>
        /// Processes command string
        /// </summary>
        /// <param name="command">command string to process</param>
        /// <param name="message">report from robot or error message</param>
        /// <returns>Returns true if command was successful else returns false</returns>
        bool ProcessCommand(RobotCommand command, string[] args, out string message);

        /// <summary>
        /// Sets EndOfSimulation flag to true
        /// </summary>
        void EndSimulation();
    }
}
