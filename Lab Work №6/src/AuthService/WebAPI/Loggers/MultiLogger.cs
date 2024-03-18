namespace WebAPI.Loggers
{
    public class MultiLogger : ILogger
    {
        private readonly List<ILogger> _loggers = new();

        public MultiLogger AddLoggerToConsole()
        {
            _loggers.Add(LoggerToConsole.GetInstance());

            return this;
        }

        public MultiLogger AddLoggerToFile(string fileName)
        {
            _loggers.Add(new LoggerToFile(fileName));

            return this;
        }

        public void Log(string message)
        {
            _loggers.ForEach(logger => logger.Log(message));
        }
    }
}
