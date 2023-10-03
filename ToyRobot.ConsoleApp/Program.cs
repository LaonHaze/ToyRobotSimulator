using ToyRobot.Service;
using ToyRobot.Service.Interfaces;
using System.Configuration;

namespace ToyRobot.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Toy Robot Simulator!");

            ISimulationService simulationService = new SimulationService();

            bool showError = Convert.ToBoolean(ConfigurationManager.AppSettings["ShowErrorMessage"]);

            while (simulationService.ContinueSimulation())
            {
                Console.WriteLine("Please enter a command:");
                string? line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    Console.WriteLine("Would you like to exit? Enter [Y] to exit or press enter anything to continue:");
                    string? checkExitLine = Console.ReadLine();

                    if (checkExitLine != null && checkExitLine.ToUpper() == "Y")
                    {
                        simulationService.EndSimulation();
                    }
                }
                else
                {
                    var result = simulationService.ProcessSimulationCommand(line);

                    if (!string.IsNullOrEmpty(result.Message) && (result.Success || (!result.Success && showError)))
                    {
                        Console.WriteLine(result.Message);
                    }
                }
            }
        }
    }
}