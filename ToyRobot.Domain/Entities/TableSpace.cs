using ToyRobot.Domain.Interfaces;

namespace ToyRobot.Domain.Entities
{
    public class TableSpace : ISpace<SimplePlacement>
    {
        /// <summary>
        /// Maximum values for x and y. Exclusive.
        /// </summary>
        private readonly int _maxX;
        private readonly int _maxY;

        /// <summary>
        /// Constants for minimum values. Inclusive.
        /// </summary>
        private readonly int _minX;
        private readonly int _minY;

        /// <summary>
        /// Sets rectangular table boundaries
        /// </summary>
        /// <param name="height">Height of table area</param>
        /// <param name="width">Width of table area</param>
        public TableSpace(int height, int width)
        {
            _maxX = width;
            _maxY = height;
            _minX = 0;
            _minY = 0;
        }

        public bool IsValidPosition(SimplePlacement position)
        {
            return position.X >= _minX && position.Y >= _minY && position.X < _maxX && position.Y < _maxY;
        }
    }
}
