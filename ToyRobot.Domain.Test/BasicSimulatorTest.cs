using Moq;
using ToyRobot.Domain.Constants;
using ToyRobot.Domain.Entities;
using ToyRobot.Domain.Enums;
using ToyRobot.Domain.Interfaces;
using Xunit.Sdk;

namespace ToyRobot.Domain.Test
{
    [TestClass]
    public class BasicSimulatorTest
    {
        private Mock<ISpace<SimplePlacement>> _mockTable = new Mock<ISpace<SimplePlacement>>();
        private Mock<IRobot<SimplePlacement>> _mockRobot = new Mock<IRobot<SimplePlacement>>();
        private Mock<IPlacementResolver<SimplePlacement>> _mockResolver = new Mock<IPlacementResolver<SimplePlacement>>();

        [TestInitialize] 
        public void Setup()
        {
            _mockRobot.Setup(x => x.UpdatePlacement(It.IsAny<SimplePlacement>())).Verifiable();
        }

        [TestMethod]
        public void TestPlaceCommandSuccess()
        {           
            BasicSimulator basicSimulator = new BasicSimulator(_mockRobot.Object, _mockTable.Object, _mockResolver.Object);

            _mockRobot.Setup(x => x.Place(It.IsAny<SimplePlacement>())).Verifiable();
            _mockTable.Setup(x => x.IsValidPosition(
                    It.Is<SimplePlacement>(v => v.X < 5 && v.Y < 5 && v.X >= 0 && v.Y >= 0)
                    )).Returns(true);

            var result = basicSimulator.ProcessCommand(CommandCode.PLACE, new string[] { "1", "2", "NORTH" }, out string message);

            _mockRobot.Verify(x => x.Place(new SimplePlacement(1, 2, CompassDirection.North)));
            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, message);
        }

        [TestMethod]
        public void TestPlaceCommandInvalidArgumentFailure()
        {
            BasicSimulator basicSimulator = new BasicSimulator(_mockRobot.Object, _mockTable.Object, _mockResolver.Object);

            _mockRobot.Setup(x => x.Place(It.IsAny<SimplePlacement>())).Verifiable();
            _mockTable.Setup(x => x.IsValidPosition(
                    It.Is<SimplePlacement>(v => v.X < 5 && v.Y < 5 && v.X >= 0 && v.Y >= 0)
                    )).Returns(true);

            var result = basicSimulator.ProcessCommand(CommandCode.PLACE, new string[] { "1", "2", "NORT" }, out string message);

            _mockRobot.Verify(x => x.Place(It.IsAny<SimplePlacement>()), Times.Never());
            Assert.IsFalse(result);
            Assert.AreEqual(Constants.ErrorMessage.ARGUMENT_PARSING_ERROR + ": 1, 2, NORT", message);
        }

        [TestMethod]
        public void TestPlaceCommandInvalidPositionFailure()
        {
            BasicSimulator basicSimulator = new BasicSimulator(_mockRobot.Object, _mockTable.Object, _mockResolver.Object);

            _mockRobot.Setup(x => x.Place(It.IsAny<SimplePlacement>())).Verifiable();
            _mockTable.Setup(x => x.IsValidPosition(
                    It.Is<SimplePlacement>(v => v.X < 5 && v.Y < 5 && v.X >= 0 && v.Y >= 0)
                    )).Returns(true);

            var result = basicSimulator.ProcessCommand(CommandCode.PLACE, new string[] { "5", "5", "NORTH" }, out string message);

            _mockRobot.Verify(x => x.Place(It.IsAny<SimplePlacement>()), Times.Never());
            Assert.IsFalse(result);
            Assert.AreEqual($"Invalid placement at 5,5,NORTH", message);
        }

        [TestMethod]
        public void TestMoveCommandSuccess()
        {
            BasicSimulator basicSimulator = new BasicSimulator(_mockRobot.Object, _mockTable.Object, _mockResolver.Object);
            SimplePlacement originalPlacement = new SimplePlacement(1, 1, CompassDirection.North);
            SimplePlacement newPlacement = new SimplePlacement(1, 2, CompassDirection.North);

            _mockRobot.Setup(x => x.IsPlaced).Returns(true);
            _mockRobot.Setup(x => x.Placement).Returns(originalPlacement);
            _mockResolver.Setup(x => x.MoveForward(originalPlacement)).Returns(newPlacement);
            _mockTable.Setup(x => x.IsValidPosition(
                    It.Is<SimplePlacement>(v => v.X < 5 && v.Y < 5 && v.X >= 0 && v.Y >= 0)
                    )).Returns(true);

            var result = basicSimulator.ProcessCommand(CommandCode.MOVE, Array.Empty<string>(), out string message);

            _mockRobot.Verify(x => x.UpdatePlacement(newPlacement));
            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, message);
        }

        [TestMethod]
        public void TestMoveCommandFailureToOutOfBounds()
        {
            BasicSimulator basicSimulator = new BasicSimulator(_mockRobot.Object, _mockTable.Object, _mockResolver.Object);
            SimplePlacement originalPlacement = new SimplePlacement(1, 1, CompassDirection.North);
            SimplePlacement newPlacement = new SimplePlacement(1, 2, CompassDirection.North);

            _mockRobot.Setup(x => x.IsPlaced).Returns(true);
            _mockRobot.Setup(x => x.Placement).Returns(originalPlacement);
            _mockResolver.Setup(x => x.MoveForward(originalPlacement)).Returns(newPlacement);
            _mockTable.Setup(x => x.IsValidPosition(
                    It.IsAny<SimplePlacement>())).Returns(false);

            var result = basicSimulator.ProcessCommand(CommandCode.MOVE, Array.Empty<string>(), out string message);

            _mockRobot.Verify(x => x.UpdatePlacement(newPlacement), Times.Never());
            Assert.IsFalse(result);
            Assert.AreEqual($"Invalid movement from {originalPlacement} to {newPlacement}", message);
        }

        [TestMethod]
        public void TestLeftCommandSuccess()
        {
            BasicSimulator basicSimulator = new BasicSimulator(_mockRobot.Object, _mockTable.Object, _mockResolver.Object);
            SimplePlacement originalPlacement = new SimplePlacement(1, 1, CompassDirection.North);
            SimplePlacement newPlacement = new SimplePlacement(1, 1, CompassDirection.West);

            _mockRobot.Setup(x => x.IsPlaced).Returns(true);
            _mockRobot.Setup(x => x.Placement).Returns(originalPlacement);
            _mockResolver.Setup(x => x.TurnLeft(originalPlacement)).Returns(newPlacement);
            _mockTable.Setup(x => x.IsValidPosition(
                    It.Is<SimplePlacement>(v => v.X < 5 && v.Y < 5 && v.X >= 0 && v.Y >= 0)
                    )).Returns(true);

            var result = basicSimulator.ProcessCommand(CommandCode.LEFT, Array.Empty<string>(), out string message);

            _mockRobot.Verify(x => x.UpdatePlacement(newPlacement));
            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, message);
        }

        [TestMethod]
        public void TestRightCommandSuccess()
        {
            BasicSimulator basicSimulator = new BasicSimulator(_mockRobot.Object, _mockTable.Object, _mockResolver.Object);
            SimplePlacement originalPlacement = new SimplePlacement(1, 1, CompassDirection.North);
            SimplePlacement newPlacement = new SimplePlacement(1, 1, CompassDirection.East);

            _mockRobot.Setup(x => x.IsPlaced).Returns(true);
            _mockRobot.Setup(x => x.Placement).Returns(originalPlacement);
            _mockResolver.Setup(x => x.TurnRight(originalPlacement)).Returns(newPlacement);
            _mockTable.Setup(x => x.IsValidPosition(
                    It.Is<SimplePlacement>(v => v.X < 5 && v.Y < 5 && v.X >= 0 && v.Y >= 0)
                    )).Returns(true);

            var result = basicSimulator.ProcessCommand(CommandCode.RIGHT, Array.Empty<string>(), out string message);

            _mockRobot.Verify(x => x.UpdatePlacement(newPlacement));
            Assert.IsTrue(result);
            Assert.AreEqual(string.Empty, message);
        }

        [TestMethod]
        public void TestReportCommandSuccess()
        {
            BasicSimulator basicSimulator = new BasicSimulator(_mockRobot.Object, _mockTable.Object, _mockResolver.Object);
            SimplePlacement originalPlacement = new SimplePlacement(1, 1, CompassDirection.North);
            SimplePlacement newPlacement = new SimplePlacement(1, 1, CompassDirection.West);

            _mockRobot.Setup(x => x.Report()).Returns("1,1,NORTH");

            var result = basicSimulator.ProcessCommand(CommandCode.REPORT, Array.Empty<string>(), out string message);

            Assert.IsTrue(result);
            Assert.AreEqual("1,1,NORTH", message);
        }
    }
}