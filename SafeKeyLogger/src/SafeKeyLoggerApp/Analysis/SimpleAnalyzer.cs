using System;
using System.Collections.Generic;
using System.IO;
using SafeKeyLoggerApp.Interfaces;

namespace SafeKeyLoggerApp.Analysis
{
    public class SimpleAnalyzer : IAnalyzer
    {
        public Dictionary<string, int> AnalyzeFrequency(string logFilePath)
        {
            var dict = new Dictionary<string,int>(StringComparer.OrdinalIgnoreCase);
            if (!File.Exists(logFilePath)) return dict;
            foreach (var line in File.ReadAllLines(logFilePath))
            {
                var parts = line.Split('\t', 2);
                if (parts.Length < 2) continue;
                var desc = parts[1].Trim();
                if (!dict.ContainsKey(desc)) dict[desc]=0;
                dict[desc]++;
            }
            return dict;
        }

        public string ExportCsv(string csvPath)
        {
            var freq = AnalyzeFrequency(csvPath.Replace(".csv",".txt")); // convenience
            using var sw = new StreamWriter(csvPath);
            sw.WriteLine("Description,Count");
            foreach (var kv in freq)
            {
                sw.WriteLine($"\"{kv.Key}\",{kv.Value}");
            }
            return csvPath;
        }
    }
}
