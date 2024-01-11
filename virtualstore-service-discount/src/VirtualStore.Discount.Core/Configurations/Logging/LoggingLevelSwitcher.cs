using Serilog.Core;
using Serilog.Events;

namespace VirtualStore.Discount.Core.Configurations.Logging;

public class LoggingLevelSwitcher
{
    private static readonly Lazy<LoggingLevelSwitch> _lazy = new Lazy<LoggingLevelSwitch>(() => new LoggingLevelSwitch());
    public static LoggingLevelSwitch _instance => _lazy.Value;

    public static void ChangeLoggingLEvel(string newLoggingLevel)
    {
        _instance.MinimumLevel = (Enum.TryParse<LogEventLevel>(newLoggingLevel, ignoreCase: true, out var result) ? result : LogEventLevel.Warning);
    }
}