using Moq;
using ToyRobot.Domain.Entities;
using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Interfaces;
using Xunit.Sdk;

namespace ToyRobot.Domain.Test
{
    [TestClass]
    public class ToyRobotTest
    {
        //Mock<ITable<(int, int)>> _mockTable = new Mock<ITable<(int, int)>>();

        //[TestInitialize] public void Init() {
        //    _mockTable.CallBase = true;
        //    _mockTable.Setup(x => x.IsValidPosition(
        //        It.Is<(int X, int Y)>(v => v.X < 5 && v.Y < 5 && v.X >= 0 && v.Y >=0)
        //        )).Returns(true);
        //    _mockTable.Setup(x => x.IsValidPosition(
        //        It.Is<(int X, int Y)>(v => v.X >= 5 || v.Y >= 5 || v.X < 0 || v.Y < 0)
        //        )).Returns(false);
        //}

        //[TestMethod]
        //public void TestPlaceRobotReport()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();
        //    int x = 0;
        //    int y = 0;
        //    CompassDirection direction = CompassDirection.East;

        //    toyRobot.Place(_mockTable.Object, (x, y), direction);

        //    Assert.AreEqual(x, toyRobot.Coords.X);
        //    Assert.AreEqual(y, toyRobot.Coords.Y);
        //    Assert.AreEqual(direction, toyRobot.Orientation);

        //    string report = toyRobot.Report();

        //    Assert.AreEqual($"{x},{y},{direction.ToString().ToUpper()}", report);
        //}

        //[TestMethod]
        //public void TestPlaceRobotAtOrigin()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();

        //    toyRobot.Place(_mockTable.Object, (0, 0), CompassDirection.East);

        //    Assert.AreEqual(0, toyRobot.Coords.X);
        //    Assert.AreEqual(0, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.East, toyRobot.Orientation);
        //}

        //[TestMethod]
        //public void TestPlaceRobotWithInBound()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();

        //    toyRobot.Place(_mockTable.Object, (3, 2), CompassDirection.North);

        //    Assert.AreEqual(3, toyRobot.Coords.X);
        //    Assert.AreEqual(2, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.North, toyRobot.Orientation);
        //}

        //[TestMethod]
        //public void TestPlaceRobotOutOfBound()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();

        //    toyRobot.Place(_mockTable.Object, (5, 5), CompassDirection.North);

        //    Assert.AreEqual(default, toyRobot.Coords.X);
        //    Assert.AreEqual(default, toyRobot.Coords.Y);
        //    Assert.AreEqual(default, toyRobot.Orientation);
        //}

        //[TestMethod]
        //public void TestPlaceRobotAndMoveInBoundY()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();

        //    toyRobot.Place(_mockTable.Object, (3, 2), CompassDirection.North);

        //    Assert.AreEqual(3, toyRobot.Coords.X);
        //    Assert.AreEqual(2, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.North, toyRobot.Orientation);

        //    toyRobot.MoveForward();

        //    Assert.AreEqual(3, toyRobot.Coords.X);
        //    Assert.AreEqual(3, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.North, toyRobot.Orientation);

        //    string report = toyRobot.Report();

        //    Assert.AreEqual("3,3,NORTH", report);
        //}

        //[TestMethod]
        //public void TestPlaceRobotAndTryMoveOutBoundY()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();

        //    toyRobot.Place(_mockTable.Object, (0, 4), CompassDirection.North);

        //    Assert.AreEqual(0, toyRobot.Coords.X);
        //    Assert.AreEqual(4, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.North, toyRobot.Orientation);

        //    toyRobot.MoveForward();

        //    Assert.AreEqual(0, toyRobot.Coords.X);
        //    Assert.AreEqual(4, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.North, toyRobot.Orientation);

        //    string report = toyRobot.Report();

        //    Assert.AreEqual("0,4,NORTH", report);
        //}

        //[TestMethod]
        //public void TestPlaceRobotAndMoveInBoundX()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();

        //    toyRobot.Place(_mockTable.Object, (3, 2), CompassDirection.East);

        //    Assert.AreEqual(3, toyRobot.Coords.X);
        //    Assert.AreEqual(2, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.East, toyRobot.Orientation);

        //    toyRobot.MoveForward();

        //    Assert.AreEqual(4, toyRobot.Coords.X);
        //    Assert.AreEqual(2, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.East, toyRobot.Orientation);

        //    string report = toyRobot.Report();

        //    Assert.AreEqual("4,2,EAST", report);
        //}

        //[TestMethod]
        //public void TestPlaceRobotAndTryMoveOutBoundX()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();

        //    toyRobot.Place(_mockTable.Object, (4, 2), CompassDirection.East);

        //    Assert.AreEqual(4, toyRobot.Coords.X);
        //    Assert.AreEqual(2, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.East, toyRobot.Orientation);

        //    toyRobot.MoveForward();

        //    Assert.AreEqual(4, toyRobot.Coords.X);
        //    Assert.AreEqual(2, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.East, toyRobot.Orientation);

        //    string report = toyRobot.Report();

        //    Assert.AreEqual("4,2,EAST", report);
        //}

        //[TestMethod]
        //public void TestPlaceRobotAndTurnRight()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();

        //    toyRobot.Place(_mockTable.Object, (4, 2), CompassDirection.East);

        //    Assert.AreEqual(4, toyRobot.Coords.X);
        //    Assert.AreEqual(2, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.East, toyRobot.Orientation);

        //    toyRobot.TurnRight();

        //    Assert.AreEqual(4, toyRobot.Coords.X);
        //    Assert.AreEqual(2, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.South, toyRobot.Orientation);

        //    string report = toyRobot.Report();

        //    Assert.AreEqual("4,2,SOUTH", report);
        //}

        //[TestMethod]
        //public void TestPlaceRobotAndTurnLeft()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();

        //    toyRobot.Place(_mockTable.Object, (4, 2), CompassDirection.East);

        //    Assert.AreEqual(4, toyRobot.Coords.X);
        //    Assert.AreEqual(2, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.East, toyRobot.Orientation);

        //    toyRobot.TurnLeft();

        //    Assert.AreEqual(4, toyRobot.Coords.X);
        //    Assert.AreEqual(2, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.North, toyRobot.Orientation);

        //    string report = toyRobot.Report();

        //    Assert.AreEqual("4,2,NORTH", report);
        //}

        //[TestMethod]
        //public void TestPlaceRobotAndTurnLeftFromNorth()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();

        //    toyRobot.Place(_mockTable.Object, (4, 2), CompassDirection.North);

        //    Assert.AreEqual(4, toyRobot.Coords.X);
        //    Assert.AreEqual(2, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.North, toyRobot.Orientation);

        //    toyRobot.TurnLeft();

        //    Assert.AreEqual(4, toyRobot.Coords.X);
        //    Assert.AreEqual(2, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.West, toyRobot.Orientation);

        //    string report = toyRobot.Report();

        //    Assert.AreEqual("4,2,WEST", report);
        //}

        //[TestMethod]
        //public void TestPlaceRobotAndTurnRightFromWest()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();

        //    toyRobot.Place(_mockTable.Object, (4, 2), CompassDirection.West);

        //    Assert.AreEqual(4, toyRobot.Coords.X);
        //    Assert.AreEqual(2, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.West, toyRobot.Orientation);

        //    toyRobot.TurnRight();

        //    Assert.AreEqual(4, toyRobot.Coords.X);
        //    Assert.AreEqual(2, toyRobot.Coords.Y);
        //    Assert.AreEqual(CompassDirection.North, toyRobot.Orientation);

        //    string report = toyRobot.Report();

        //    Assert.AreEqual("4,2,NORTH", report);
        //}

        //[TestMethod]
        //public void TestInvalidPlacementIgnoreSubsequentCommands()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();

        //    toyRobot.Place(_mockTable.Object, (5, 0), CompassDirection.West);

        //    Assert.AreEqual(default, toyRobot.Coords.X);
        //    Assert.AreEqual(default, toyRobot.Coords.Y);
        //    Assert.AreEqual(default, toyRobot.Orientation);

        //    toyRobot.MoveForward();

        //    Assert.AreEqual(default, toyRobot.Coords.X);
        //    Assert.AreEqual(default, toyRobot.Coords.Y);
        //    Assert.AreEqual(default, toyRobot.Orientation);

        //    string report = toyRobot.Report();

        //    Assert.AreEqual(string.Empty, report);
        //}

        //[TestMethod]
        //public void TestMovingBeforePlacementDoesNotMove()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();

        //    toyRobot.MoveForward();

        //    Assert.AreEqual(default, toyRobot.Coords.X);
        //    Assert.AreEqual(default, toyRobot.Coords.Y);
        //    Assert.AreEqual(default, toyRobot.Orientation);

        //    string report = toyRobot.Report();

        //    Assert.AreEqual(string.Empty, report);
        //}

        //[TestMethod]
        //public void TestTurningBeforePlacementDoesNotMove()
        //{
        //    IToyRobot<(int X, int Y), CompassDirection> toyRobot = new Entities.ToyRobot();

        //    toyRobot.TurnRight();

        //    Assert.AreEqual(default, toyRobot.Coords.X);
        //    Assert.AreEqual(default, toyRobot.Coords.Y);
        //    Assert.AreEqual(default, toyRobot.Orientation);

        //    string report = toyRobot.Report();

        //    Assert.AreEqual(string.Empty, report);
        //}
    }
}