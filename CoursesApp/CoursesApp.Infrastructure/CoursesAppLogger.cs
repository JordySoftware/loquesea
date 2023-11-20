using Microsoft.Extensions.Logging;

namespace CoursesApp.Infrastructure
{
    public class CoursesAppLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{logLevel}: ");
            Console.ResetColor();

            Console.Write(formatter(state, exception));
            Console.WriteLine();
        }
    }

    public class CoursesAppLoggerProvider : ILoggerProvider
    {
        private readonly List<ILogger> loggers = new List<ILogger>();

        public ILogger CreateLogger(string categoryName)
        {
            var logger = new CoursesAppLogger();
            loggers.Add(logger);

            return logger;
        }

        public void Dispose() => loggers.Clear();
    }
}
