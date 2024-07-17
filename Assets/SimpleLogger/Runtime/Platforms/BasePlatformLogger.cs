namespace konsnos.SimpleLogger.Platforms
{
    internal abstract class BasePlatformLogger
    {
        public abstract void Log(LogLevel logLevel, string message, object context);
    }
}
