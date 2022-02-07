using NLog;
using NLog.Config;

namespace Parser.Core
{
    public static class LoggerConfig
    {
        public static void ConfigureNlog()
        {
            var config = new LoggingConfiguration();
            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            LogManager.Configuration = config;
        }
     
    }
}
