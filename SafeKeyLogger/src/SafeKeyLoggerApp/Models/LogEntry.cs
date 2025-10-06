using System;

namespace SafeKeyLoggerApp.Models
{
    public class LogEntry
    {
        public DateTime Timestamp { get; init; }
        public string Description { get; init; } = string.Empty;
    }
}
