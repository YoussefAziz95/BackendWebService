using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record LoggingAllRequest(
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
string? CorrelationId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<LoggingAllResponse>>
{
    public IValidator<LoggingAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<LoggingAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

