using System.Configuration;
using ToyRobot.Service.Interfaces;
using ToyRobot.Service;

namespace ToyRobot.ConsoleApp
{
    internal class Simulation
    {
        private const string TABLE_SIZE_KEY = "TableSize";
        private readonly ISimulationService _simulationService;
        private readonly bool _showError;
        private readonly bool _showPrompt;

        internal Simulation()
        {
            IDictionary<string, string?> config = new Dictionary<string, string?>{
                { TABLE_SIZE_KEY,  ConfigurationManager.AppSettings[TABLE_SIZE_KEY] }
            };

            _showError = Convert.ToBoolean(ConfigurationManager.AppSettings["ShowErrorMessage"]);
            _showPrompt = Convert.ToBoolean(ConfigurationManager.AppSettings["ShowPrompt"]);

            // Dependency injection if possible
            ISimulatorFactory simulatorFactory = new SimulatorFactory(config);
            _simulationService = new SimulationService(simulatorFactory);
        }

        internal void Run()
        {
            Console.WriteLine("Press enter to start entering command via console or enter a file path to run");
            var answer = Console.ReadLine();

            if (string.IsNullOrEmpty(answer))
            {
                RunUser();
            }
            else
            {
                RunFile(answer);
            }
        }

        internal void RunFile(string? filePath)
        {
            string[] lines;

            if (!string.IsNullOrEmpty(filePath))
            {
                 lines = File.ReadAllLines(filePath);
            }
            else
            {
                Console.WriteLine("FIle path not found. Running code on resource example file...");
                lines = Properties.Resources.Case1.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            }

            foreach (var line in lines)
                HandleLineInput(line);
        }

        internal void RunUser()
        {
            while (_simulationService.ContinueSimulation())
            {
                if (_showPrompt)
                {
                    Console.WriteLine("Please enter a command:");
                }
                string? line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    if (CheckToEndSimulation())
                    {
                        _simulationService.EndSimulation();
                    }
                }
                else
                {
                    HandleLineInput(line);
                }             
            }
        }

        private void HandleLineInput(string line)
        {
            var result = _simulationService.ProcessSimulationCommand(line);

            if (!string.IsNullOrEmpty(result.Message) && (result.Success || (!result.Success && _showError)))
            {
                Console.WriteLine(result.Success ? "Output: " + result.Message: "Error: " + result.Message);
            }
        }

        private bool CheckToEndSimulation()
        {
            Console.WriteLine("Would you like to exit? Enter [Y] to exit or press enter anything to continue:");
            string? checkExitLine = Console.ReadLine();

            if (checkExitLine != null && checkExitLine.ToUpper() == "Y")
            {
                return true;
            }

            return false;
        }
    }
}
