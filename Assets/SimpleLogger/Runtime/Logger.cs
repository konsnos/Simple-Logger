using System.Collections.Generic;

namespace konsnos.SimpleLogger
{
    public struct Logger
    {
        private readonly LogLevel _logLevel;
        
        private static readonly Dictionary<string, string> Tags = new Dictionary<string, string>();

        private static readonly string[] Colors = new[]
        {
            "ff0000",
            "00ff00",
            "0000ff",
            "ffff00",
            "ff00ff",
            "00ffff",
            "ff8000",
            "ff0080",
            "80ff00",
            "00ff80",
            "8000ff",
            "0080ff",
        };
        
        private static int _colorIndex;
        
        public Logger(LogLevel logLevel)
        {
            _logLevel = logLevel;
        }
        
        public void LogDebug(string message, object context = null, string tag = null)
        {
            Log(LogLevel.Debug, message, context, tag);
        }
        
        public void LogInfo(string message, object context = null, string tag = null)
        {
            Log(LogLevel.Info, message, context, tag);
        }
        
        public void LogWarning(string message, object context = null, string tag = null)
        {
            Log(LogLevel.Warning, message, context, tag);
        }
        
        public void LogError(string message, object context = null, string tag = null)
        {
            Log(LogLevel.Error, message, context, tag);
        }
        
        public void LogFatal(string message, object context = null, string tag = null)
        {
            Log(LogLevel.Error, message, context, tag);
        }

        public void Log(LogLevel logLevel, string message, object context = null, string tag = null)
        {
            if (_logLevel > logLevel) return;
            
            if (!string.IsNullOrEmpty(tag))
            {
                message = TagMessage(message, tag);
            }
                
            LoggerSingleton.Instance.Log(logLevel, message, context);
        }

        private static string TagMessage(string message, string tag)
        {
            if (Tags.TryGetValue(tag, out var color)) return $"<color=#{color}>[{tag}]</color> {message}";
            
            Tags[tag] = Colors[_colorIndex];
            _colorIndex = (_colorIndex + 1) % Colors.Length;

            return $"<color=#{Tags[tag]}>[{tag}]</color> {message}";
        }
    }
}
