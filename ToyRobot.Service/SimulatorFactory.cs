using ToyRobot.Domain.Entities;
using ToyRobot.Domain.Interfaces;
using ToyRobot.Service.Interfaces;

namespace ToyRobot.Service
{
    public class SimulatorFactory : ISimulatorFactory
    {
        private readonly IDictionary<string, string?> _config;
        private const int DEFAULT_TABLE_SIZE = 5;

        public SimulatorFactory(IDictionary<string, string?> config)
        {
            _config = config;
        }

        public ISimulator Create()
        {
            int tableSize;

            if (_config.TryGetValue("TableSize", out string? size))
            {
                tableSize = int.TryParse(size, out int sizeInt) ? sizeInt : DEFAULT_TABLE_SIZE;
            }
            else
            {
                tableSize = DEFAULT_TABLE_SIZE;
            }

            IRobot<SimplePlacement> robot = new BasicRobot();
            ISpace<SimplePlacement> space = new TableSpace(tableSize, tableSize);
            
            return new BasicSimulator(robot, space);
        }
    }
}
