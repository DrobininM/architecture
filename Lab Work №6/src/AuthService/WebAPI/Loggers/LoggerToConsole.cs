namespace WebAPI.Loggers
{
    public class LoggerToConsole : ILogger
    {
        private static LoggerToConsole _logger;

        private LoggerToConsole() { }

        public static LoggerToConsole GetInstance()
        {
            if (_logger is null)
            {
                _logger = new LoggerToConsole();
            }

            return _logger;
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
