namespace BruteForceOpfer
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            if (args.Length == 1)
            {
                if (args[0] == "MeinPasswort!")
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}