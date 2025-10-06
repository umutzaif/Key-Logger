using System;

namespace SafeKeyLoggerApp.Interfaces
{
    public interface IKeyLogger
    {
        void Start();
        void Stop();
        event Action<Models.LogEntry> OnLog;
    }
}
