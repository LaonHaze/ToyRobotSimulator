using ToyRobot.Domain.Constants;
using ToyRobot.Domain.Entities;
using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Interfaces;
using ToyRobot.Service.Constants;
using ToyRobot.Service.Helpers;
using ToyRobot.Service.Interfaces;
using ToyRobot.Service.Models;

namespace ToyRobot.Service
{
    public class SimulationService : ISimulationService
    {
        private readonly ISimulator<RobotCommand> _simulator;
        private bool _endOfSimulation;
          
        public SimulationService()
        {
            // Ideally, Simulator set up belongs in a factory class, and should be injected here
            _simulator = new BasicSimulator(new BasicRobot(), new TableSpace(5, 5));
            _endOfSimulation = false;
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
                        _endOfSimulation = true;
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