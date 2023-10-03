using ToyRobot.Domain.Entities;
using ToyRobot.Domain.Interfaces;
using Xunit.Sdk;

namespace ToyRobot.Domain.Test
{
    [TestClass]
    public class TableTest
    {
        [TestMethod]
        public void TestCorners()
        {
            ITable<(int, int)> table = new Table(5, 5);

            Assert.IsTrue(table.IsValidPosition((0, 0)));
            Assert.IsTrue(table.IsValidPosition((4, 0)));
            Assert.IsTrue(table.IsValidPosition((0, 4)));
            Assert.IsTrue(table.IsValidPosition((4, 4)));
        }

        [TestMethod]
        public void TestValuesInsideTable()
        {
            ITable<(int, int)> table = new Table(5, 5);

            Assert.IsTrue(table.IsValidPosition((3, 2)));
            Assert.IsTrue(table.IsValidPosition((1, 1)));
            Assert.IsTrue(table.IsValidPosition((2, 4)));
            Assert.IsTrue(table.IsValidPosition((0, 2)));
        }

        [TestMethod]
        public void TestOutOfBounds()
        {
            ITable<(int, int)> table = new Table(5, 5);

            Assert.IsFalse(table.IsValidPosition((0, 5)));
            Assert.IsFalse(table.IsValidPosition((5, 0)));
            Assert.IsFalse(table.IsValidPosition((7, 15)));
            Assert.IsFalse(table.IsValidPosition((15, 7)));
            Assert.IsFalse(table.IsValidPosition((15, 15)));
        }

        [TestMethod]
        public void TestNegative()
        {
            ITable<(int, int)> table = new Table(5, 5);

            Assert.IsFalse(table.IsValidPosition((0, -1)));
            Assert.IsFalse(table.IsValidPosition((-1, 0)));
        }
    }
}