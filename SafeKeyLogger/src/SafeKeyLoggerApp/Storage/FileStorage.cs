using System;
using System.IO;
using System.Text;
using SafeKeyLoggerApp.Interfaces;
using SafeKeyLoggerApp.Models;

namespace SafeKeyLoggerApp.Storage
{
    public class FileStorage : IStorage
    {
        private readonly string path;
        private readonly object sync = new object();

        public FileStorage(string path)
        {
            this.path = path;
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);
        }

        public void Append(LogEntry entry)
        {
            var line = $"{entry.Timestamp:yyyy-MM-dd HH:mm:ss.fff}\t{entry.Description}";
            lock (sync)
            {
                File.AppendAllText(path, line + Environment.NewLine, Encoding.UTF8);
            }
        }

        public void Clear()
        {
            lock (sync)
            {
                File.WriteAllText(path, string.Empty);
            }
        }

        public string GetFilePath() => path;
    }
}
