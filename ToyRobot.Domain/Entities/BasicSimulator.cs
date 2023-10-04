using ToyRobot.Domain.Constants;
using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Interfaces;

namespace ToyRobot.Domain.Entities
{
    public class BasicSimulator : ISimulator
    {
        private readonly IRobot<SimplePlacement> _robot;
        private readonly ISpace<SimplePlacement> _space;
        private readonly IPlacementResolver<SimplePlacement> _placementResolver;

        public BasicSimulator(IRobot<SimplePlacement> robot, ISpace<SimplePlacement> space, IPlacementResolver<SimplePlacement> placementResolver) {
            _robot = robot;
            _space = space;
            _placementResolver = placementResolver;
        }

        public bool ProcessCommand(string commandCode, string[] args, out string message)
        {
            bool result = true;
            message = string.Empty;

            switch (commandCode)
            {
                case CommandCode.PLACE:
                    result = UpdatePlacementFromArgs(args, ref message);
                    break;
                case CommandCode.MOVE:
                    result = UpdateRobotPlacement(_placementResolver.MoveForward(_robot.Placement), ref message);
                    break;
                case CommandCode.LEFT:
                    result = UpdateRobotPlacement(_placementResolver.TurnLeft(_robot.Placement), ref message);
                    break;
                case CommandCode.RIGHT:
                    result = UpdateRobotPlacement(_placementResolver.TurnRight(_robot.Placement), ref message);
                    break;
                case CommandCode.REPORT:
                    message = _robot.Report();
                    break;
                default:
                    result = false;
                    message = $"{ErrorMessage.UNKNOWN_COMMAND_CODE}: {commandCode}";
                    break;
            }

            return result;
        }

        private bool UpdateRobotPlacement(SimplePlacement newPlacement, ref string message)
        {
            if (_space.IsValidPosition(newPlacement))
            {
                _robot.UpdatePlacement(newPlacement);
                return true;
            }

            message = $"Invalid movement from {_robot.Placement} to {newPlacement}";
            return false;
        }

        private bool UpdatePlacementFromArgs(string[] args, ref string message)
        {
            if (int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y) && Enum.TryParse(args[2], true, out CompassDirection compassDirection))
            {
                SimplePlacement newPlacement = new SimplePlacement(x, y, compassDirection);

                if (_space.IsValidPosition(newPlacement))
                {
                    _robot.Place(newPlacement);
                    return true;
                }

                message = $"Invalid placement at {newPlacement}";
            }
            else
            {
                message = $"{ErrorMessage.ARGUMENT_PARSING_ERROR}: {string.Join(", ", args)}";
            }

            return false;
        }
    }
}
