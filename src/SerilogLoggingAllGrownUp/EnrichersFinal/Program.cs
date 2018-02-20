using System;
using Serilog;

namespace EnrichersFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .Enrich.WithMachineName()
                .Enrich.WithProperty("Version", "1.0.0")
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
