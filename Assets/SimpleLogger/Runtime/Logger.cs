namespace konsnos.SimpleLogger
{
    public struct Logger
    {
        private readonly LogLevel _logLevel;
        
        public Logger(LogLevel logLevel)
        {
            _logLevel = logLevel;
        }
        
        public void LogDebug(string message, object context = null)
        {
            Log(LogLevel.Debug, message, context);
        }
        
        public void LogInfo(string message, object context = null)
        {
            Log(LogLevel.Info, message, context);
        }
        
        public void LogWarning(string message, object context = null)
        {
            Log(LogLevel.Warning, message, context);
        }
        
        public void LogError(string message, object context = null)
        {
            Log(LogLevel.Error, message, context);
        }
        
        public void LogFatal(string message, object context = null)
        {
            Log(LogLevel.Error, message, context);
        }

        public void Log(LogLevel logLevel, string message, object context = null)
        {
            if (_logLevel <= logLevel)
                LoggerSingleton.Instance.Log(logLevel, message, context);
        }
    }
}
