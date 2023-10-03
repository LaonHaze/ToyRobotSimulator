using ToyRobot.Domain.Constants;
using ToyRobot.Domain.Entities;
using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Interfaces;
using ToyRobot.Service.Helpers;
using ToyRobot.Service.Interfaces;
using ToyRobot.Service.Models;

namespace ToyRobot.Service
{
    public class SimulationService : ISimulationService
    {
        private readonly ISimulator _simulator;
          
        public SimulationService()
        {
            // Ideally, Toy Robot and Table should go into a factory and be set up for DI.
            _simulator = new BasicSimulator(new Domain.Entities.ToyRobot(), new Table(5, 5));
        }

        public SimulationResult ProcessSimulationCommand(string command)
        {
            bool success = true;
            string message = string.Empty;

            try
            {
                string commandCode = CommandHelper.ProcessAndValidateCommand(command, out string[] args);

                switch (commandCode)
                {
                    case CommandCode.PLACE:
                    case CommandCode.MOVE:
                    case CommandCode.LEFT:
                    case CommandCode.RIGHT:
                    case CommandCode.REPORT:
                        if (Enum.TryParse(commandCode, true, out RobotCommand robotCommand))
                        {
                            success = _simulator.ProcessCommand(robotCommand, args, out message);
                        }                          
                        break;
                    case CommandCode.EXIT:
                        _simulator.EndSimulation();
                        message = SystemMessage.END_SIMULATION;
                        break;
                    case CommandCode.ERROR:
                    default:
                        success = false;
                        message = args.Length == 1 ? args[0] : ErrorMessage.UNKNOWN_ERROR;
                        break;
                }
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                success = false;
            }

            return new SimulationResult
            {
                Success = success,
                Message = message
            };
        }

        public bool ContinueSimulation()
        {
            return !_simulator.EndOfSimulation;
        }
    }
}