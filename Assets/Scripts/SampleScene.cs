using System.Threading.Tasks;
using konsnos.SimpleLogger;
using TMPro;
using UnityEngine;
using Logger = konsnos.SimpleLogger.Logger;

public class SampleScene : MonoBehaviour
{
    private Logger _logger = new Logger(LogLevel.Debug);
    
    [SerializeField] private TMP_Dropdown instanceLoggerDropdown;
    [SerializeField] private TMP_Dropdown singletonLoggerDropdown;

    private void Start()
    {
        instanceLoggerDropdown.onValueChanged.AddListener(InstanceLoggerLogLevelChanged);
        singletonLoggerDropdown.onValueChanged.AddListener(SingletonLoggerLogLevelChanged);
    }

    public void LogDebug()
    {
        _logger.LogDebug("Debug log", gameObject);
    }
    
    public void LogInfo()
    {
        _logger.LogInfo("Info log", gameObject);
    }
    
    public void LogWarning()
    {
        _logger.LogWarning("Warning log", gameObject);
    }
    
    public void LogError()
    {
        _logger.LogError("Error log", gameObject);
    }
    
    public void LogFatal()
    {
        _logger.LogFatal("Fatal log", gameObject);
    }

    public async void LogAsync()
    {
        _logger.LogDebug("Logging async", gameObject);

        await Task.Run(() =>
        {
            _logger.LogDebug("Log in async");
        });
        
        _logger.LogDebug("Logging async done", gameObject);
    }

    private void InstanceLoggerLogLevelChanged(int value)
    {
        var logLevel = (LogLevel)value;
        _logger.LogInfo($"Creating new logger with log level {logLevel}", gameObject);
        _logger = new Logger(logLevel);
    }

    private void SingletonLoggerLogLevelChanged(int value)
    {
        var logLevel = (LogLevel)value;
        _logger.LogInfo($"Logger Singleton log level: {logLevel}", gameObject);
        LoggerSingleton.Instance.LogLevel = LogLevel.Debug;
    }
}
