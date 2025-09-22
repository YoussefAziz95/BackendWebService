using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record LoggingAllResponse(
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
string? CorrelationId) : IConvertibleFromEntity<Logging, LoggingAllResponse>
{
    public static LoggingAllResponse FromEntity(Logging Logging) =>
    new LoggingAllResponse(
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