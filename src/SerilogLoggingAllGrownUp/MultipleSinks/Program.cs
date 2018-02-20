using System;
using Serilog;

namespace MultipleSinks
{
    class Program
    {
        static void Main(string[] args)
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
