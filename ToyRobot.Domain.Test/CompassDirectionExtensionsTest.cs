using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Extensions;
using Xunit.Sdk;

namespace ToyRobot.Domain.Test
{
    [TestClass]
    public class CompassDirectionExtensionsTest
    {
        [TestMethod]
        public void RotateClockwiseDirection()
        {
            CompassDirection compassDirection = CompassDirection.North;

            compassDirection = compassDirection.Turn(1);

            Assert.AreEqual(CompassDirection.East, compassDirection);
        }

        [TestMethod]
        public void RotateAnticlockwiseDirection()
        {
            CompassDirection compassDirection = CompassDirection.East;

            compassDirection = compassDirection.Turn(-1);

            Assert.AreEqual(CompassDirection.North, compassDirection);
        }

        [TestMethod]
        public void RotateAnticlockwiseDirectionFromNorth()
        {
            CompassDirection compassDirection = CompassDirection.North;

            compassDirection = compassDirection.Turn(-1);

            Assert.AreEqual(CompassDirection.West, compassDirection);
        }

        [TestMethod]
        public void RotateClockwiseDirectionFromWest()
        {
            CompassDirection compassDirection = CompassDirection.West;

            compassDirection = compassDirection.Turn(1);

            Assert.AreEqual(CompassDirection.North, compassDirection);
        }

        [TestMethod]
        public void RotateClockwiseDirectionTwice()
        {
            CompassDirection compassDirection = CompassDirection.North;

            compassDirection = compassDirection.Turn(2);

            Assert.AreEqual(CompassDirection.South, compassDirection);
        }

        [TestMethod]
        public void RotateClockwiseDirectionFourTimes()
        {
            CompassDirection compassDirection = CompassDirection.North;

            compassDirection = compassDirection.Turn(4);

            Assert.AreEqual(CompassDirection.North, compassDirection);
        }

        [TestMethod]
        public void ReportString()
        {
            CompassDirection compassDirection = CompassDirection.North;

            Assert.AreEqual("NORTH", compassDirection.ToReportString());
        }
    }
}