using Ganzenbord.Business;

namespace Ganzenbord
{
    public class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            Console.WriteLine(message);
        }

        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}