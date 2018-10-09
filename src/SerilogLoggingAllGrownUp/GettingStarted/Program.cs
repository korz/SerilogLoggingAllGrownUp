using System;
using Serilog;
using Serilog.Events;

namespace GettingStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstLook();
            StaticInstance();
            CertainLevel();
        }

        static void FirstLook()
        {
            ILogger logger = new LoggerConfiguration()
                .WriteTo.RollingFile(@"C:\temp\logs\log.txt", LogEventLevel.Information)
                .CreateLogger();

            logger.Information("Did something");
            //Log.Logger.Information();
        }

        static void StaticInstance()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"C:\Temp\logs\log.txt").CreateLogger();

            Log.Logger.Information("Starting Service");

            try
            {
                Log.Logger.Warning("Trying to do something");
                throw new InvalidOperationException("You can't do that.");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "I don't know something happed.");
            }

            Log.Logger.Information("Stopping Service");
        }

        static void CertainLevel()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"C:\Temp\logs\log.txt"
                , LogEventLevel.Warning).CreateLogger();

            Log.Logger.Information("Starting Service");

            try
            {
                Log.Logger.Warning("Trying to do something");
                throw new InvalidOperationException("You can't do that.");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "I don't know something happed.");
            }

            Log.Logger.Information("Stopping Service");
        }
    }
}
