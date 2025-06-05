namespace Application.Features;

public record Logger(string Message, string LogType, string? Suggestion, string SourceLayer, string SourceClass, int SourceLineNumber, int? UserId, DateTime Timestamp);