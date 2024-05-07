using System.Diagnostics;

namespace BruteForceAlgo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ProcessHandler processHandler = new();

            BruteForce bruteForce = new(processHandler);

            bruteForce.StartBruteForce();
        }
    }
}