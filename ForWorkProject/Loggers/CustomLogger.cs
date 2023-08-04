using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Serilog;
using Serilog.Events;

namespace ForWorkProject.Loggers;


public class CustomLogger
{
    
    public static Serilog.Core.Logger WriteLogToFile(IConfiguration configuration, string filePath)
    {
        var logger = new LoggerConfiguration().WriteTo.File(filePath,LogEventLevel.Error).CreateLogger();
        return logger;
    }
}
