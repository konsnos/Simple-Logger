using System;
using UnityEngine;

namespace konsnos.SimpleLogger.Platforms
{
    internal class UnityPlatformLogger : BasePlatformLogger
    {
        public override void Log(LogLevel logLevel, string message, object context)
        {
            var unityContext = context as UnityEngine.Object;
            var unityMessage = message as object;
            switch (logLevel)
            {
                case LogLevel.Debug:
                    Debug.unityLogger.Log(LogType.Log, unityMessage, unityContext);
                    break;
                case LogLevel.Info:
                    Debug.unityLogger.Log(LogType.Log, unityMessage, unityContext);
                    break;
                case LogLevel.Warning:
                    Debug.unityLogger.Log(LogType.Warning, unityMessage, unityContext);
                    break;
                case LogLevel.Error:
                    Debug.unityLogger.Log(LogType.Error, unityMessage, unityContext);
                    break;
                case LogLevel.Fatal:
                    Debug.unityLogger.Log(LogType.Error, unityMessage, unityContext);
                    break;
                default:
                    throw new Exception($"Unknown log level: {logLevel}");
            }
        }
    }
}
