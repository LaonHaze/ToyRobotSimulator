using ToyRobot.Domain.Interfaces;

namespace ToyRobot.Domain.Entities
{
    public class Table : ITable<(int X, int Y)>
    {
        /// <summary>
        /// Maximum values for x and y. Inclusive.
        /// </summary>
        private readonly int _maxX; 
        private readonly int _maxY;

        /// <summary>
        /// Constants for minimum values. Inclusive.
        /// </summary>
        private const int _minX = 0;
        private const int _minY = 0;

        public Table(int height, int width) {
            _maxX = width;
            _maxY = height;
        }

        public bool IsValidPosition((int X, int Y) position)
        {
            return position.X >= _minX && position.X <= _maxX && position.Y >= _minY && position.Y <= _maxY;
        }
    }
}
