using ToyRobot.Domain.Entities;
using ToyRobot.Domain.Enums;
using Xunit.Sdk;

namespace ToyRobot.Domain.Test
{
    [TestClass]
    public class TableSpaceTest
    {
        private readonly TableSpace _table = new TableSpace(5, 5); 
        private readonly TableSpace _largeTable = new TableSpace(10, 10);

        [TestMethod]
        public void TestCorners()
        {
            Assert.IsTrue(_table.IsValidPosition(new SimplePlacement(0, 0, CompassDirection.North)));
            Assert.IsTrue(_table.IsValidPosition(new SimplePlacement(4, 0, CompassDirection.North)));
            Assert.IsTrue(_table.IsValidPosition(new SimplePlacement(0, 4, CompassDirection.North)));
            Assert.IsTrue(_table.IsValidPosition(new SimplePlacement(4, 4, CompassDirection.North)));
        }

        [TestMethod]
        public void TestValuesInsideTable()
        {
            Assert.IsTrue(_table.IsValidPosition(new SimplePlacement(3, 2, CompassDirection.North)));
            Assert.IsTrue(_table.IsValidPosition(new SimplePlacement(1, 1, CompassDirection.East)));
            Assert.IsTrue(_table.IsValidPosition(new SimplePlacement(2, 4, CompassDirection.West)));
            Assert.IsTrue(_table.IsValidPosition(new SimplePlacement(0, 2, CompassDirection.North)));
        }

        [TestMethod]
        public void TestOutOfBounds()
        {
            Assert.IsFalse(_table.IsValidPosition(new SimplePlacement(0, 5, CompassDirection.North)));
            Assert.IsFalse(_table.IsValidPosition(new SimplePlacement(5, 0, CompassDirection.North)));
            Assert.IsFalse(_table.IsValidPosition(new SimplePlacement(5, 5, CompassDirection.North)));
            Assert.IsFalse(_table.IsValidPosition(new SimplePlacement(8, 9, CompassDirection.North)));
            Assert.IsFalse(_table.IsValidPosition(new SimplePlacement(8, 9, CompassDirection.East)));
        }

        [TestMethod]
        public void TestNegative()
        {
            Assert.IsFalse(_table.IsValidPosition(new SimplePlacement(-1, -1, CompassDirection.North)));
            Assert.IsFalse(_table.IsValidPosition(new SimplePlacement(0, -2, CompassDirection.North)));
            Assert.IsFalse(_table.IsValidPosition(new SimplePlacement(0, -2, CompassDirection.East)));
        }

        [TestMethod]
        public void TestLargeTable()
        {
            Assert.IsTrue(_largeTable.IsValidPosition(new SimplePlacement(0, 5, CompassDirection.North)));
            Assert.IsTrue(_largeTable.IsValidPosition(new SimplePlacement(5, 0, CompassDirection.North)));
            Assert.IsTrue(_largeTable.IsValidPosition(new SimplePlacement(5, 5, CompassDirection.North)));
            Assert.IsTrue(_largeTable.IsValidPosition(new SimplePlacement(8, 9, CompassDirection.North)));
            Assert.IsTrue(_largeTable.IsValidPosition(new SimplePlacement(8, 9, CompassDirection.East)));
        }
    }
}