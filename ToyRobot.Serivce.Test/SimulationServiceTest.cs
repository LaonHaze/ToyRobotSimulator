using Moq;
using ToyRobot.Domain.Constants;
using ToyRobot.Domain.Interfaces;
using ToyRobot.Service;
using ToyRobot.Service.Interfaces;
using ToyRobot.Service.Models;

namespace ToyRobot.Serivce.Test
{
    [TestClass]
    public class SimulationServiceTest
    {
        private Mock<ISimulatorFactory> _mockFactory = new Mock<ISimulatorFactory>();
        private Mock<ISimulator> _mockSimulator = new Mock<ISimulator>();

        [TestInitialize] 
        public void Init()
        {
            _mockFactory.Setup(x => x.Create()).Returns(_mockSimulator.Object);

        }

        [TestMethod]
        public void TestExitSimulation()
        {
            SimulationService simulationService = new SimulationService(_mockFactory.Object);

            SimulationResult result = simulationService.ProcessSimulationCommand(CommandCode.EXIT);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestPlaceSimulationSucess()
        {
            string expectedValue = string.Empty;
            SimulationService simulationService = new SimulationService(_mockFactory.Object);
            _mockSimulator.Setup(x => x.ProcessCommand(It.IsAny<string>(), It.IsAny<string[]>(), out expectedValue)).Returns(true);

            SimulationResult result = simulationService.ProcessSimulationCommand(CommandCode.PLACE + " 1,1,NORTH");

            Assert.IsTrue(result.Success);
            Assert.AreEqual(expectedValue, result.Message);
        }

        [TestMethod]
        public void TestPlaceSimulationMissingArgs()
        {
            string expectedValue = string.Empty;
            SimulationService simulationService = new SimulationService(_mockFactory.Object);
            _mockSimulator.Setup(x => x.ProcessCommand(It.IsAny<string>(), It.IsAny<string[]>(), out expectedValue)).Returns(true);

            SimulationResult result = simulationService.ProcessSimulationCommand(CommandCode.PLACE);

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Invalid command arguments", result.Message);
        }

        [TestMethod]
        public void TestMoveSimulationSuccess()
        {
            string expectedValue = string.Empty;
            SimulationService simulationService = new SimulationService(_mockFactory.Object);
            _mockSimulator.Setup(x => x.ProcessCommand(It.IsAny<string>(), It.IsAny<string[]>(), out expectedValue)).Returns(true);

            SimulationResult result = simulationService.ProcessSimulationCommand(CommandCode.MOVE);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(expectedValue, result.Message);
        }

        [TestMethod]
        public void TestMoveSimulationFailure()
        {
            string expectedValue = "Error";
            SimulationService simulationService = new SimulationService(_mockFactory.Object);
            _mockSimulator.Setup(x => x.ProcessCommand(It.IsAny<string>(), It.IsAny<string[]>(), out expectedValue)).Returns(false);

            SimulationResult result = simulationService.ProcessSimulationCommand(CommandCode.MOVE);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(expectedValue, result.Message);
        }

        [TestMethod]
        public void TestRightSimulationSuccess()
        {
            string expectedValue = string.Empty;
            SimulationService simulationService = new SimulationService(_mockFactory.Object);
            _mockSimulator.Setup(x => x.ProcessCommand(It.IsAny<string>(), It.IsAny<string[]>(), out expectedValue)).Returns(true);

            SimulationResult result = simulationService.ProcessSimulationCommand(CommandCode.RIGHT);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(expectedValue, result.Message);
        }

        [TestMethod]
        public void TestLeftSimulationSuccess()
        {
            string expectedValue = string.Empty;
            SimulationService simulationService = new SimulationService(_mockFactory.Object);
            _mockSimulator.Setup(x => x.ProcessCommand(It.IsAny<string>(), It.IsAny<string[]>(), out expectedValue)).Returns(true);

            SimulationResult result = simulationService.ProcessSimulationCommand(CommandCode.LEFT);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(expectedValue, result.Message);
        }

        [TestMethod]
        public void TestReportSimulationSuccess()
        {
            string expectedValue = "1,1,EAST";
            SimulationService simulationService = new SimulationService(_mockFactory.Object);
            _mockSimulator.Setup(x => x.ProcessCommand(It.IsAny<string>(), It.IsAny<string[]>(), out expectedValue)).Returns(true);

            SimulationResult result = simulationService.ProcessSimulationCommand(CommandCode.REPORT);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(expectedValue, result.Message);
        }
    }
}