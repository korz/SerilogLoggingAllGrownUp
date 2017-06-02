using System;
using Serilog;

namespace MultipleSinks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add References to Serilog.Sinks.Literate

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
    }
}
