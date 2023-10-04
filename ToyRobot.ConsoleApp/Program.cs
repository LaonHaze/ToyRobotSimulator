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

            string tableSizeKey = "TableSize";

            IDictionary<string, string?> config = new Dictionary<string, string?>{
                { tableSizeKey,  ConfigurationManager.AppSettings[tableSizeKey] }
            };

            // Dependency injection if possible
            ISimulatorFactory simulatorFactory = new SimulatorFactory(config);
            ISimulationService simulationService = new SimulationService(simulatorFactory);

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