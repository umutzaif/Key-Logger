using System;
using System.IO;

namespace SafeKeyLoggerApp.Exporter
{
    // This exporter DOES NOT send data over network.
    // It simulates 'sending' by copying the source file into an outbox directory.
    public class SafeExporter
    {
        private readonly string outboxDir;
        public SafeExporter(string outboxDir)
        {
            this.outboxDir = outboxDir;
            Directory.CreateDirectory(outboxDir);
        }

        public string Export(string sourceFile)
        {
            if (!File.Exists(sourceFile)) throw new FileNotFoundException(sourceFile);
            var dest = Path.Combine(outboxDir, $"export_{DateTime.Now:yyyyMMdd_HHmmss}.log");
            File.Copy(sourceFile, dest, true);
            return dest;
        }
    }
}
