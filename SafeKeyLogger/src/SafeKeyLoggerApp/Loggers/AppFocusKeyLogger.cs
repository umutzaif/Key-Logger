using System;
using SafeKeyLoggerApp.Interfaces;
using SafeKeyLoggerApp.Models;

namespace SafeKeyLoggerApp.Loggers
{
    public class AppFocusKeyLogger : IKeyLogger
    {
        private readonly IStorage storage;
        private bool running = false;
        public event Action<LogEntry>? OnLog;

        public AppFocusKeyLogger(IStorage storage)
        {
            this.storage = storage;
        }

        public void Start() => running = true;
        public void Stop() => running = false;

        // Called by the Form's key events
        public void AppendLocal(string description)
        {
            if (!running) return;
            var entry = new LogEntry { Timestamp = DateTime.Now, Description = description };
            storage.Append(entry);
            OnLog?.Invoke(entry);
        }
    }
}
