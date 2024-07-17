# Simple Logger

A simple Log system that incorporates Log Levels to select for printing. `Logger` is instanced and can be created with different Log Levels while `LoggerSingleton` has its own Log Level and can control log printing universally in the project. 


## Usage

Create a new Logger with 

```
Logger _logger = new Logger(LogLevel.Debug);
```

and print with 

```
_logger.LogDebug("Debug log", gameObject);
```

The Log Level only can be changed in the constructor of the Logger. However, the `LoggerSingleton` Log Level can be set at any time with 

```
LoggerSingleton.Instance.LogLevel = LogLevel.Debug;
```
 
## Setup

### Requirements
* Unity 2021.3 or later

### Installation

1. Open the Package Manager from Window > Package Manager.
2. Click the "+" button > Add package from git URL.
3. Enter the following URL:

```
https://github.com/konsnos/Simple-Logger.git?path=Assets/SimpleLogger
```

Alternatively, open Packages/manifest.json and add the following to the dependencies block:

```json
{
    "dependencies": {
        "com.konsnos.simplelogger": "https://github.com/konsnos/Simple-Logger.git?path=Assets/SimpleLogger"
    }
}
```

### Troubleshooting

In case there is confusion due to multiple Logger classes available the following code will always select the Simple Logger

```
using Logger = konsnos.SimpleLogger.Logger;
```

or you can type the full namespace

```
konsnos.SimpleLogger.Logger _logger = new konsnos.SimpleLogger.Logger(LogLevel.Debug);
```
