using ToyRobot.Domain.Constants;
using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Interfaces;

namespace ToyRobot.Domain.Entities
{
    public class BasicSimulator : ISimulator
    {
        private readonly IRobot<SimplePlacement> _robot;
        private readonly ISpace<SimplePlacement> _space;

        public BasicSimulator(IRobot<SimplePlacement> robot, ISpace<SimplePlacement> space) {
            _robot = robot;
            _space = space;
        }

        public bool ProcessCommand(string commandCode, string[] args, out string message)
        {
            bool result = true;
            message = string.Empty;

            switch (commandCode)
            {
                case CommandCode.PLACE:
                    result = UpdatePlacementFromArgs(args);
                    message = result ? string.Empty : ErrorMessage.ARGUMENT_PARSING_ERROR + $": {string.Join(", ", args)}";
                    break;
                case CommandCode.MOVE:
                    UpdateRobotPlacement(_robot.Placement.MoveForward());
                    break;
                case CommandCode.LEFT:
                    UpdateRobotPlacement(_robot.Placement.TurnLeft());
                    break;
                case CommandCode.RIGHT:
                    UpdateRobotPlacement(_robot.Placement.TurnRight());
                    break;
                case CommandCode.REPORT:
                    message = _robot.Report();
                    break;
                default:
                    result = false;
                    message = ErrorMessage.UNKNOWN_COMMAND_CODE + $": {commandCode}";
                    break;
            }

            return result;
        }

        private void UpdateRobotPlacement(SimplePlacement newPlacement)
        {
            if (_space.IsValidPosition(newPlacement))
            {
                _robot.UpdatePlacement(newPlacement);
            }
        }

        private bool UpdatePlacementFromArgs(string[] args)
        {
            if (int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y) && Enum.TryParse(args[2], true, out CompassDirection compassDirection))
            {
                _robot.Place(new SimplePlacement(x, y, compassDirection));
                return true;
            }

            return false;
        }
    }
}
