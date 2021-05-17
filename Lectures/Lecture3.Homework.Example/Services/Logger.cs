using Lecture3.Homework.Example.Contracts;
using System;
using System.IO;

namespace Lecture3.Homework.Example.Services
{
    public class Logger : StreamWriter, ILogger
    {
        private readonly LoggerOptions _options;

        public Logger() : base("")
        {
        }

        public Logger(IOptions<LoggerOptions> options) : base("")
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void Log(string message)
        {
            throw new NotImplementedException();
        }

        public class LoggerOptions
        {
            public string FileNameToSaveContent { get; set; }
        }
    }
}