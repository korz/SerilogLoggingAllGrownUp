using System;
using Serilog;

namespace CreateYourOwnSinkFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.KorzSink()
                .Enrich.WithProperty("AppName", "SerilogLoggingAllGrownUp")
                .Enrich.WithProperty("Version", "1.0.0.0")
                .CreateLogger();

            Log.Logger.Information("Let's see how this looks.");

            Console.ReadKey();
        }
    }
}
