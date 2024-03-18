namespace WebAPI.Loggers
{
    public class MultiLoggerComposite : ILogger
    {
        private readonly List<ILogger> _loggers = new();

        public void AddLogger(ILogger logger)
        {
            _loggers.Add(logger);
        }

        public void Log(string message)
        {
            _loggers.ForEach(logger => logger.Log(message));
        }
    }
}
