using Application.Contracts.Features;
using Application.Profiles;
using Domain;
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
string? CorrelationId) : IConvertibleFromEntity<Logging, LoggingResponse>
{
    public static LoggingResponse FromEntity(Logging Logging) =>
    new LoggingResponse(
    Logging.UserId,
    Logging.Message,
    Logging.ExceptionCode,
    Logging.KeyExceptionMessage,
    Logging.LogType,
    Logging.Suggestion,
    Logging.Timestamp,
    Logging.SourceLayer,
    Logging.SourceClass,
    Logging.SourceLineNumber,
    Logging.CorrelationId
    );
}