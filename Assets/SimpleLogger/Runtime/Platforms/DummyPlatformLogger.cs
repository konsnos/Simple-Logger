namespace konsnos.SimpleLogger.Platforms
{
    internal class DummyPlatformLogger : BasePlatformLogger
    {
        public override void Log(LogLevel logLevel, string message, object context)
        {
            // nothing to do
        }
    }
}