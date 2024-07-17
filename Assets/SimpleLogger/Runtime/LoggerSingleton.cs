using konsnos.SimpleLogger.Platforms;

namespace konsnos.SimpleLogger
{
    public class LoggerSingleton
    {
        private static LoggerSingleton _instance;
        private readonly BasePlatformLogger _platformLogger;

        public LogLevel LogLevel { get; set; } = LogLevel.Debug;

        private LoggerSingleton()
        {
            _platformLogger = new UnityPlatformLogger();
        }

        public static LoggerSingleton Instance => _instance ??= new LoggerSingleton();
        
        public void Log(LogLevel logLevel, string message, object context = null)
        {
            if(LogLevel <= logLevel)
                _platformLogger.Log(logLevel, message, context);
        }
    }
    
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error,
        Fatal
    }
}
