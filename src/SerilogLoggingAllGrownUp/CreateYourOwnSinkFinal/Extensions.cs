using Serilog;
using Serilog.Configuration;

namespace CreateYourOwnSinkFinal
{
    public static class Extensions
    {
        public static LoggerConfiguration KorzSink(this LoggerSinkConfiguration loggerSinkConfiguration)
        {
            return loggerSinkConfiguration.Sink(new KorzSink());
        }
    }
}
