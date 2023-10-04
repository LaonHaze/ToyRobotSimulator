namespace ToyRobot.Domain.Interfaces
{
    public interface ISpace<TPlacement> where TPlacement : IPlacement
    {
        /// <summary>
        /// Checks if given position is a valid position in the space
        /// </summary>
        /// <param name="position">Position to check</param>
        /// <returns>True if possible to place in given position</returns>
        bool IsValidPosition(TPlacement position);
    }
}
