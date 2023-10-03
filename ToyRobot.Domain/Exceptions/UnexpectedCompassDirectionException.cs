using ToyRobot.Domain.Enums;

namespace ToyRobot.Domain.Exceptions
{
    public class UnexpectedCompassDirectionException : Exception
    {
        public CompassDirection CompassDirection { get; private set; }

        public UnexpectedCompassDirectionException() { }
        public UnexpectedCompassDirectionException(string message) : base(message) { }
        public UnexpectedCompassDirectionException(string message, Exception inner) : base(message, inner) { }

        public UnexpectedCompassDirectionException(string message, CompassDirection compassDirection) : base(message)
        {
            CompassDirection = compassDirection;
        }
    }
}
