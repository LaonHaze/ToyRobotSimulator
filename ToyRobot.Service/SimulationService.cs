using ToyRobot.Domain.Constants;
using ToyRobot.Domain.Interfaces;
using ToyRobot.Service.Constants;
using ToyRobot.Service.Helpers;
using ToyRobot.Service.Interfaces;
using ToyRobot.Service.Models;

namespace ToyRobot.Service
{
    public class SimulationService : ISimulationService
    {
        private readonly ISimulator _simulator;
        private bool _endOfSimulation;
          
        public SimulationService(ISimulatorFactory simulatorFactory)
        {
            _simulator = simulatorFactory.Create();
            _endOfSimulation = false;
        }

        public SimulationResult ProcessSimulationCommand(string command)
        {
            bool success = true;
            string message;

            try
            {
                string commandCode = CommandHelper.ProcessAndValidateCommand(command, out string[] args);

                switch (commandCode)
                {
                    case CommandCode.EXIT:
                        _endOfSimulation = true;
                        message = SystemMessage.END_SIMULATION;
                        break;
                    case CommandCode.ERROR:
                        success = false;
                        message = args.Length == 1 ? args[0] : ErrorMessage.UNKNOWN_ERROR;
                        break;
                    default:
                        success = _simulator.ProcessCommand(commandCode, args, out message);
                        break;
                }
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.ToString();
            }

            return new SimulationResult
            {
                Success = success,
                Message = message
            };
        }

        public bool ContinueSimulation()
        {
            return !_endOfSimulation;
        }

        public void EndSimulation()
        {
            _endOfSimulation = true;
        }
    }
}