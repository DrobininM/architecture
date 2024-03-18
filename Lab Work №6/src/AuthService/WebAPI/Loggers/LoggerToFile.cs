namespace WebAPI.Loggers
{
    public class LoggerToFile : ILogger
    {
        private readonly string _fileName;

        public LoggerToFile(string fileName)
        {
            _fileName = fileName;
        }

        public void Log(string message)
        {
            StreamWriter fileStream = null;

            try
            {
                fileStream = new StreamWriter(_fileName, true);

                fileStream.WriteLine(message);
            }
            finally
            {
                fileStream?.Dispose();
            }
        }
    }
}
