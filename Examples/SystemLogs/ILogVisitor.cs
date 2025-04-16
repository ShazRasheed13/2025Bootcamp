using System;
using System.Collections.Generic;

namespace Examples.SystemLogs
{
    public interface ILogVisitor
    {
        void Visit(InfoLog log);
        void Visit(WarningLog log);
        void Visit(ErrorLog log);
    }

    public class LogCounterVisitor : ILogVisitor
    {
        public int InfoCount { get; private set; }
        public int WarningCount { get; private set; }
        public int ErrorCount { get; private set; }

        public void Visit(InfoLog infoLog) => InfoCount++;
        public void Visit(WarningLog warningLog) => WarningCount++;
        public void Visit(ErrorLog errorLog) => ErrorCount++;
    }

    public class SeverityReporterVisitor : ILogVisitor
    {
        private readonly List<string> _report = new();

        public void Visit(InfoLog log) => 
            _report.Add($"[INFO] {log.Timestamp:HH:mm:ss} - {log.Message}");

        public void Visit(WarningLog log) => 
            _report.Add($"[WARNING] {log.Timestamp:HH:mm:ss} - {log.Message}");

        public void Visit(ErrorLog log) => 
            _report.Add($"[ERROR] {log.Timestamp:HH:mm:ss} - {log.Message}");

        public IEnumerable<string> GetReport() => _report;
    }
}
