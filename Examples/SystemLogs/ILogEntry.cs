namespace Examples.SystemLogs;

public interface ILogEntry
{
    void Accept(ILogVisitor visitor);
}

public class InfoLog(string message, DateTime timestamp) : ILogEntry
{
    public string Message { get; } = message;
    public DateTime Timestamp { get; } = timestamp;

    public void Accept(ILogVisitor visitor) => visitor.Visit(this);
}

public class WarningLog(string message, DateTime timestamp) : ILogEntry
{
    public string Message { get; } = message;
    public DateTime Timestamp { get; } = timestamp;

    public void Accept(ILogVisitor visitor) => visitor.Visit(this);
}

public class ErrorLog(string message, DateTime timestamp) : ILogEntry
{
    public string Message { get; } = message;
    public DateTime Timestamp { get; } = timestamp;

    public void Accept(ILogVisitor visitor) => visitor.Visit(this);
}

