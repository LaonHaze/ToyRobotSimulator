using ToyRobot.Domain.Constants;

namespace ToyRobot.Service.Helpers
{
    /// <summary>
    /// This should become a proper class with interface to allow mocking for testing purposed.
    /// </summary>
    internal static class CommandHelper
    {
        public static string ProcessAndValidateCommand(string command, out string[] args)
        {
            string[] commandParts = command.Split(" ");

            if (commandParts.Length == 0)
            {
                args = new[] { ErrorMessage.EMPTY_COMMAND };
                return CommandCode.ERROR;
            }

            string commandCode = commandParts[0].ToUpper();

            // Argument processing and validation for given command codes
            switch (commandCode)
            {
                case CommandCode.PLACE:
                    if (commandParts.Length == 2)
                    {
                        args = commandParts[1].Split(",");
                    }
                    else
                    {
                        args = new[] { ErrorMessage.INVALID_ARGUMENTS };
                        commandCode = CommandCode.ERROR;
                    }
                    break;
                case CommandCode.MOVE:
                case CommandCode.LEFT:
                case CommandCode.RIGHT:
                case CommandCode.REPORT:
                case CommandCode.EXIT:
                    if (commandParts.Length > 1)
                    {
                        args = new[] { ErrorMessage.INVALID_ARGUMENTS };
                        commandCode = CommandCode.ERROR;
                    }
                    else
                    {
                        args = Array.Empty<string>();
                    }
                    break;
                default:
                    args = new[] { ErrorMessage.UNKNOWN_COMMAND_CODE };
                    commandCode = CommandCode.ERROR;
                    break;
            }

            return commandCode;
        }
    }
}
