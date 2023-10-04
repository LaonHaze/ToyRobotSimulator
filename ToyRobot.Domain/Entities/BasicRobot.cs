using ToyRobot.Domain.Interfaces;

namespace ToyRobot.Domain.Entities
{
    public class BasicRobot : IRobot<SimplePlacement>
    {
        public bool IsPlaced { get; private set; }

        public SimplePlacement Placement { get; private set; }

        public void Place(SimplePlacement placement)
        {
            Placement = placement;
            IsPlaced = true;
        }

        public string Report()
        {
            return IsPlaced ? Placement.ToString() : string.Empty;
        }

        public void UpdatePlacement(SimplePlacement placement)
        {
            if (IsPlaced)
            {
                Placement = placement;
            }
        }
    }
}