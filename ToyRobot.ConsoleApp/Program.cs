using ToyRobot.Service;
using ToyRobot.Service.Interfaces;

namespace ToyRobot.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Toy Robot Simulator!");

            ISimulationService simulationService = new SimulationService();

            while (simulationService.ContinueSimulation())
            {
                Console.WriteLine("Please enter a command:");
                string? line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                else
                {
                    var result = simulationService.ProcessSimulationCommand(line);

                    if (!string.IsNullOrEmpty(result.Message))
                    {
                        Console.WriteLine(result.Message);
                    }
                }
            }
        }
    }
}