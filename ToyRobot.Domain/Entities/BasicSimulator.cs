using ToyRobot.Domain.Constants;
using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Helpers;
using ToyRobot.Domain.Interfaces;

namespace ToyRobot.Domain.Entities
{
    public class BasicSimulator : ISimulator
    {
        private readonly IToyRobot<(int, int), CompassDirection> _toyRobot;
        private readonly ITable<(int, int)> _table;

        public bool EndOfSimulation { get; private set; }

        public BasicSimulator(IToyRobot<(int, int), CompassDirection> toyRobot, ITable<(int, int)> table) {
            _toyRobot = toyRobot;
            _table = table;
        }

        public bool ProcessCommand(RobotCommand command, string[] args, out string message)
        {
            bool result = true;
            message = string.Empty;

            switch (command)
            {
                case RobotCommand.Place:                   
                    if (int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y) && Enum.TryParse(args[2], true, out CompassDirection compassDirection))
                    {
                        _toyRobot.Place(_table, (x, y), compassDirection);
                    }
                    else
                    {
                        result = false;
                        message = ErrorMessage.ARGUMENT_PARSING_ERROR + $": {string.Join(", ", args)}";
                    }
                    break;
                case RobotCommand.Move:
                    _toyRobot.MoveForward();
                    break;
                case RobotCommand.Left:
                    _toyRobot.TurnLeft();
                    break;
                case RobotCommand.Right:
                    _toyRobot.TurnRight();
                    break;
                case RobotCommand.Report:
                    message = _toyRobot.Report();
                    break;
                default:
                    result = false;
                    message = ErrorMessage.UNIMPLEMENTED_COMMAND;
                    break;
            }

            return result;
        }

        public void EndSimulation()
        {
            EndOfSimulation = true;
        }
    }
}
