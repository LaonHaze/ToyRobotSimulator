using ToyRobot.Domain.Entities;
using ToyRobot.Domain.Enums;
using Xunit.Sdk;

namespace ToyRobot.Domain.Test
{
    [TestClass]
    public class BasicRobotTest
    {
        [TestMethod]
        public void TestInitialisesAsUnplaced()
        {
            BasicRobot basicRobot = new BasicRobot();

            Assert.IsFalse(basicRobot.IsPlaced);
        }

        [TestMethod]
        public void TestReportUnplaced()
        {
            BasicRobot basicRobot = new BasicRobot();

            Assert.IsFalse(basicRobot.IsPlaced);
            Assert.AreEqual(string.Empty, basicRobot.Report());
        }

        [TestMethod]
        public void TestReportAfterUnplacedUpdated()
        {
            BasicRobot basicRobot = new BasicRobot();
            SimplePlacement newPlacement = new SimplePlacement(1, 1, CompassDirection.East);

            basicRobot.UpdatePlacement(newPlacement);

            Assert.IsFalse(basicRobot.IsPlaced);

            Assert.AreNotEqual(default, newPlacement);
            Assert.AreEqual(default, basicRobot.Placement);
            Assert.AreNotEqual(newPlacement, basicRobot.Placement);

            Assert.AreEqual(string.Empty, basicRobot.Report());
        }

        [TestMethod]
        public void TestPlace()
        {
            BasicRobot basicRobot = new BasicRobot();
            SimplePlacement newPlacement = new SimplePlacement(1, 1, CompassDirection.East);

            basicRobot.Place(newPlacement);

            Assert.IsTrue(basicRobot.IsPlaced);

            Assert.AreNotEqual(default, newPlacement);
            Assert.AreNotEqual(default, basicRobot.Placement);
            Assert.AreEqual(newPlacement, basicRobot.Placement);
        }

        [TestMethod]
        public void TestReportAfterPlace()
        {
            BasicRobot basicRobot = new BasicRobot();
            SimplePlacement newPlacement = new SimplePlacement(1, 1, CompassDirection.East);

            basicRobot.Place(newPlacement);

            Assert.IsTrue(basicRobot.IsPlaced);

            Assert.AreNotEqual(default, newPlacement);
            Assert.AreNotEqual(default, basicRobot.Placement);
            Assert.AreEqual(newPlacement, basicRobot.Placement);

            Assert.AreEqual("1,1,EAST", basicRobot.Report());
        }

        [TestMethod]
        public void TestUpdatePlacement()
        {
            BasicRobot basicRobot = new BasicRobot();
            SimplePlacement originalPlacement = new SimplePlacement(1, 1, CompassDirection.East);
            SimplePlacement newPlacement = new SimplePlacement(2, 1, CompassDirection.East);

            basicRobot.Place(originalPlacement);
            basicRobot.UpdatePlacement(newPlacement);

            Assert.IsTrue(basicRobot.IsPlaced);

            Assert.AreNotEqual(originalPlacement, newPlacement);
            Assert.AreNotEqual(originalPlacement, basicRobot.Placement);
            Assert.AreEqual(newPlacement, basicRobot.Placement);
        }

        [TestMethod]
        public void TestReportAfterUpdatePlacement()
        {
            BasicRobot basicRobot = new BasicRobot();
            SimplePlacement originalPlacement = new SimplePlacement(1, 1, CompassDirection.East);
            SimplePlacement newPlacement = new SimplePlacement(2, 1, CompassDirection.East);

            basicRobot.Place(originalPlacement);
            basicRobot.UpdatePlacement(newPlacement);

            Assert.IsTrue(basicRobot.IsPlaced);

            Assert.AreNotEqual(originalPlacement, newPlacement);
            Assert.AreNotEqual(originalPlacement, basicRobot.Placement);
            Assert.AreEqual(newPlacement, basicRobot.Placement);

            Assert.AreEqual("2,1,EAST", basicRobot.Report());
        }
    }
}