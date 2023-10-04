using ToyRobot.Domain.Entities;
using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Interfaces;
using Xunit.Sdk;

namespace ToyRobot.Domain.Test
{
    [TestClass]
    public class PlacementResolverTest
    {
        private PlacementResolver _resolver = new PlacementResolver();

        [TestMethod]
        public void TestMoveForward()
        {
            int x = 0;
            int y = 0;
            CompassDirection cd = CompassDirection.North;

            SimplePlacement placement = new SimplePlacement(x, y, cd);
            SimplePlacement newPlacement = _resolver.MoveForward(placement);

            Assert.AreEqual(0, newPlacement.X);
            Assert.AreEqual(1, newPlacement.Y);
            Assert.AreEqual(CompassDirection.North, newPlacement.CompassDirection);
        }

        [TestMethod]
        public void TestTurnRight()
        {
            int x = 0;
            int y = 0;
            CompassDirection cd = CompassDirection.North;

            SimplePlacement placement = new SimplePlacement(x, y, cd);
            SimplePlacement newPlacement = _resolver.TurnRight(placement);

            Assert.AreEqual(0, newPlacement.X);
            Assert.AreEqual(0, newPlacement.Y);
            Assert.AreEqual(CompassDirection.East, newPlacement.CompassDirection);
        }

        [TestMethod]
        public void TestTurnLeft()
        {
            int x = 0;
            int y = 0;
            CompassDirection cd = CompassDirection.East;

            SimplePlacement placement = new SimplePlacement(x, y, cd);
            SimplePlacement newPlacement = _resolver.TurnLeft(placement);

            Assert.AreEqual(0, newPlacement.X);
            Assert.AreEqual(0, newPlacement.Y);
            Assert.AreEqual(CompassDirection.North, newPlacement.CompassDirection);
        }

        [TestMethod]
        public void TestTurnLeftFromNorth()
        {
            int x = 0;
            int y = 0;
            CompassDirection cd = CompassDirection.North;

            SimplePlacement placement = new SimplePlacement(x, y, cd);
            SimplePlacement newPlacement = _resolver.TurnLeft(placement);

            Assert.AreEqual(0, newPlacement.X);
            Assert.AreEqual(0, newPlacement.Y);
            Assert.AreEqual(CompassDirection.West, newPlacement.CompassDirection);
        }

        [TestMethod]
        public void TestTurnRightFromWest()
        {
            int x = 0;
            int y = 0;
            CompassDirection cd = CompassDirection.West;

            SimplePlacement placement = new SimplePlacement(x, y, cd);
            SimplePlacement newPlacement = _resolver.TurnRight(placement);

            Assert.AreEqual(0, newPlacement.X);
            Assert.AreEqual(0, newPlacement.Y);
            Assert.AreEqual(CompassDirection.North, newPlacement.CompassDirection);
        }
    }
}