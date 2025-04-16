using Examples.SystemLogs;

namespace UnitTests;

public class CombinedLogVisitorTests
{
    [Fact]
    public void Should_Count_And_Report_All_Log_Types_Correctly()
    {
        var logs = new List<ILogEntry>
        {
            new InfoLog("Started", new DateTime(2025, 4, 16, 9, 0, 0)),
            new WarningLog("Low disk", new DateTime(2025, 4, 16, 9, 1, 0)),
            new ErrorLog("Crash", new DateTime(2025, 4, 16, 9, 2, 0)),
            new InfoLog("User login", new DateTime(2025, 4, 16, 9, 3, 0)),
            new ErrorLog("API failure", new DateTime(2025, 4, 16, 9, 4, 0))
        };

        var counterVisitor = new LogCounterVisitor();
        var reporterVisitor = new SeverityReporterVisitor();

        foreach (var log in logs)
        {
            log.Accept(counterVisitor);
            log.Accept(reporterVisitor);
        }

        var reportLines = reporterVisitor.GetReport();

        Assert.Equal(2, counterVisitor.InfoCount);
        Assert.Equal(1, counterVisitor.WarningCount);
        Assert.Equal(2, counterVisitor.ErrorCount);

        Assert.Collection(reportLines,
            line => Assert.Equal("[INFO] 09:00:00 - Started", line),
            line => Assert.Equal("[WARNING] 09:01:00 - Low disk", line),
            line => Assert.Equal("[ERROR] 09:02:00 - Crash", line),
            line => Assert.Equal("[INFO] 09:03:00 - User login", line),
            line => Assert.Equal("[ERROR] 09:04:00 - API failure", line)
        );
    }
}