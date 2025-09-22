using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record LoggingRequest(
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
string? CorrelationId) : IRequest<LoggingResponse>
{
public IValidator<LoggingRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<LoggingRequest> validator)
{
throw new NotImplementedException();
}
}

