using ToyRobot.Domain.Enums;

namespace ToyRobot.Domain.Exceptions
{
    public class UnexpectedRobotCommandException : Exception
    {
        public RobotCommand RobotCommand { get; private set; }

        public UnexpectedRobotCommandException() { }
        public UnexpectedRobotCommandException(string message) : base(message) { }
        public UnexpectedRobotCommandException(string message, Exception inner) : base(message, inner) { }

        public UnexpectedRobotCommandException(string message, RobotCommand robotCommand) : base(message)
        {
            RobotCommand = robotCommand;
        }
    }
}
