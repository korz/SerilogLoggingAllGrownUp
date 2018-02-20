using Serilog;

namespace GettingStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new LoggerConfiguration()
                .WriteTo.RollingFile(@"C:\temp\logs\log.txt")
                .CreateLogger();

            logger.Information("Did something");
            //Log.Logger.Information();
        }
    }
}
