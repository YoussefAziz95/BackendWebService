using Domain.Enums;

namespace Application.Features;
public record LoggingResponse(
int? UserId,
string? Message,
int? ExceptionCode,
string? KeyExceptionMessage,
LogTypeEnum? LogType,
string? Suggestion,
DateTime? Timestamp,
string? SourceLayer,
string? SourceClass,
int? SourceLineNumber,
string? CorrelationId);