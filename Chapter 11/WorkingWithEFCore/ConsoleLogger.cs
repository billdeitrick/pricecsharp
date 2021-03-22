using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using static System.Console;

namespace Packt.Shared
{
    class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }

        public void Dispose() { }
    }

    class ConsoleLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel level)
        {
            switch(level)
            {
                case LogLevel.Trace:
                case LogLevel.Information:
                case LogLevel.None:
                    return false;
                case LogLevel.Debug:
                case LogLevel.Warning:
                case LogLevel.Error:
                case LogLevel.Critical:
                default:
                    return true;
            };
        }

        public void Log<TState>(LogLevel level, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (eventId == 20100)
            {
                Write($"Level: {level}, Event ID: {eventId.Id}");

                if (state != null)
                {
                    Write($", State: {state}");
                }
                if (exception != null)
                {
                    Write($", Exception: {exception.Message}");
                }
                WriteLine();
            }
        }
    }
}
