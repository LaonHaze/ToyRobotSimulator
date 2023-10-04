using ToyRobot.Domain.Entities;

namespace ToyRobot.Domain.Interfaces
{
    public interface IRobot<TPlacement> where TPlacement : struct
    {
        /// <summary>
        /// Flag to check whether the robot has been placed on a board
        /// </summary>
        bool IsPlaced { get; }

        /// <summary>
        /// Current robot placement
        /// </summary>
        SimplePlacement Placement { get; }

        /// <summary>
        /// Places robot with given placement. Sets IsPlaced flag to true.
        /// </summary>
        /// <param name="placement">Placement for robot</param>
        void Place(TPlacement placement);

        /// <summary>
        /// Overwrites existing placement if robot is placed. Else placement remains unchanged
        /// </summary>
        /// <param name="placement">New placement to replace old placement</param>
        void UpdatePlacement(TPlacement placement);

        /// <summary>
        /// String report of current robot placement
        /// </summary>
        /// <returns>String report of current robot placement</returns>
        string Report();
    }
}
