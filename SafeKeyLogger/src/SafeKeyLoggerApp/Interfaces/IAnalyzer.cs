using System.Collections.Generic;
using SafeKeyLoggerApp.Models;

namespace SafeKeyLoggerApp.Interfaces
{
    public interface IAnalyzer
    {
        // Return frequency dictionary
        Dictionary<string,int> AnalyzeFrequency(string logFilePath);
        string ExportCsv(string csvPath);
    }
}
