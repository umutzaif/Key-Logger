using System.IO;
using SafeKeyLoggerApp.Storage;
using SafeKeyLoggerApp.Models;
using Xunit;

namespace SafeKeyLogger.Tests
{
    public class FileStorageTests
    {
        [Fact]
        public void Append_WritesFile()
        {
            var temp = Path.Combine(Path.GetTempPath(), "safe_keylog_test.txt");
            if (File.Exists(temp)) File.Delete(temp);
            var fs = new FileStorage(temp);
            fs.Append(new LogEntry { Timestamp = System.DateTime.Now, Description = "Test" });
            Assert.True(File.Exists(temp));
            var content = File.ReadAllText(temp);
            Assert.Contains("Test", content);
            File.Delete(temp);
        }
    }
}
