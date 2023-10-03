using ToyRobot.Domain.Enums;

namespace ToyRobot.Domain.Extensions
{
    public static class CompassDirectionExtensions
    {
        /// <summary>
        /// Turn direction by given turn value
        /// </summary>
        /// <param name="direction">starting orientation</param>
        /// <param name="turnValue">positive for clockwise and negative for anticlockwise to return next n-th direction determined by integer value</param>
        /// <returns></returns>
        public static CompassDirection Turn(this CompassDirection direction, int turnValue)
        {
            CompassDirection[] directionArray = Enum.GetValues<CompassDirection>();

            int currEnumIndex = Array.IndexOf(directionArray, direction);

            int nextEnumIndex = (currEnumIndex + turnValue) % directionArray.Length;

            return nextEnumIndex < 0 ? directionArray[nextEnumIndex + directionArray.Length] : directionArray[nextEnumIndex];
        }

        public static string ToReportString(this CompassDirection direction)
        {
            return direction.ToString().ToUpper();
        }
    }
}
