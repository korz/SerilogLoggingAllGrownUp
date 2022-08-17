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
            MultipleLoggers();
        }

        static void FirstLook()
        {
            //Create the logger
            ILogger logger = new LoggerConfiguration()
                .WriteTo.RollingFile(@"C:\temp\logs\log.txt", LogEventLevel.Information)
                .CreateLogger();

            //Log something
            logger.Information("Did something");
            //Log.Logger.Information();
        }

        static void StaticInstance()
        {
            //Create the logger
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"C:\Temp\logs\log.txt").CreateLogger();

            //Log something
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
            //Create the logger
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"C:\Temp\logs\log.txt"
                , LogEventLevel.Warning).CreateLogger();

            //Log something
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

        static void MultipleLoggers()
        {
            //Create the logger
            ILogger logger = new LoggerConfiguration()
                .WriteTo.RollingFile(pathFormat: @"C:\temp\logs\log.txt")
                .CreateLogger();

            ILogger logger2 = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .CreateLogger();

            //Log something
            logger.Information("Did something");
            logger2.Information("Log something to the console");
            //logger.Information();
        }
    }
}
