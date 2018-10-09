using System;
using Serilog;
using Serilog.Events;

namespace MultipleSinks
{
    class Program
    {
        static void Main(string[] args)
        {
            MultipleSinks();
            MultipleSinksDifferentOptions();
            MultipleLoggers();
        }

        static void MultipleSinks()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"C:\Temp\logs\MultipleSinksFinal.txt")
                .WriteTo.LiterateConsole()
                .CreateLogger();

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

            Console.ReadKey();
        }

        static void MultipleSinksDifferentOptions()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"C:\Temp\logs\MultipleSinksFinal.txt", LogEventLevel.Error)
                .WriteTo.LiterateConsole()
                .CreateLogger();

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

            Console.ReadKey();
        }

        static void MultipleLoggers()
        {
            ILogger logger = new LoggerConfiguration()
                .WriteTo.RollingFile(pathFormat: @"C:\temp\logs\log.txt")
                .CreateLogger();

            ILogger logger2 = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .CreateLogger();

            logger.Information("Did something");
            logger2.Information("Log something to the console");
            //logger.Information();
            Console.ReadKey();
        }
    }
}
