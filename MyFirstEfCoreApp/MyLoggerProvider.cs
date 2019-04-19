namespace MyFirstEfCoreApp
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.Logging;

    public class MyLoggerProvider : ILoggerProvider
    {
        private readonly List<string> logs;

        public MyLoggerProvider(List<string> logs)
        {
            this.logs = logs;
        }

        public void Dispose()
        {
            
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger(logs);
        }

        private class MyLogger : ILogger
        {
            private readonly List<string> logs;

            public MyLogger(List<string> logs)
            {
                this.logs = logs;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                logs.Add(formatter(state ,exception));
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return logLevel >= LogLevel.Information;
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }
    }
}