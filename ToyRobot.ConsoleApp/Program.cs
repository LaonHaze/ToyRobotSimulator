namespace ToyRobot.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Toy Robot Simulator!");

            Simulation simulation = new Simulation();

            simulation.Run();
        }
    }
}