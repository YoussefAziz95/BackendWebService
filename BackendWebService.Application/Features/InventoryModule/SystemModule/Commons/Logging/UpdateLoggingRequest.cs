using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UpdateLoggingRequest(
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
string? CorrelationId) : IConvertibleToEntity<Logging>
{
public Logging ToEntity() => new Logging
{
UserId = UserId,
Message = Message,
ExceptionCode = ExceptionCode,
KeyExceptionMessage = KeyExceptionMessage,
LogType = LogType,
Suggestion = Suggestion,
Timestamp = Timestamp,
SourceLayer = SourceLayer,
SourceClass = SourceClass,
SourceLineNumber = SourceLineNumber,
CorrelationId = CorrelationId
};
}