using System;

namespace Lecture3.Homework.Example.Contracts
{
    public interface ILogger : IDisposable
    {
        void Log(string message);
    }
}