using System;
using Serilog;
using Serilog.Events;

namespace MultipleSinksFinal
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
