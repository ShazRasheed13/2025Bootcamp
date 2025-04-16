using System;

namespace Examples.SystemLogs;

public interface ILogEntry
{
    void Accept(ILogVisitor visitor);
}

public class InfoLog : ILogEntry
{
    public string Message { get; }
    public DateTime Timestamp { get; }

    public InfoLog(string message, DateTime timestamp)
    {
        Message = message;
        Timestamp = timestamp;
    }

    public void Accept(ILogVisitor visitor) => visitor.Visit(this);
}

public class WarningLog : ILogEntry
{
    public string Message { get; }
    public DateTime Timestamp { get; }

    public WarningLog(string message, DateTime timestamp)
    {
        Message = message;
        Timestamp = timestamp;
    }

    public void Accept(ILogVisitor visitor) => visitor.Visit(this);
}

public class ErrorLog : ILogEntry
{
    public string Message { get; }
    public DateTime Timestamp { get; }

    public ErrorLog(string message, DateTime timestamp)
    {
        Message = message;
        Timestamp = timestamp;
    }

    public void Accept(ILogVisitor visitor) => visitor.Visit(this);
}

