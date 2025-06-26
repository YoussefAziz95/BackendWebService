using Domain.Enums;

namespace Application.Features;

public record Logger(string Message, LogTypeEnum LogType, string? Suggestion, string SourceLayer, string SourceClass, int SourceLineNumber, string? KeyExceptionMessage, ExceptionEnum? ExceptionCode, int? UserId, DateTime Timestamp);