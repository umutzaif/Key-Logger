using SafeKeyLoggerApp.Models;

namespace SafeKeyLoggerApp.Interfaces
{
    public interface IStorage
    {
        void Append(LogEntry entry);
        void Clear();
        string GetFilePath();
    }
}
