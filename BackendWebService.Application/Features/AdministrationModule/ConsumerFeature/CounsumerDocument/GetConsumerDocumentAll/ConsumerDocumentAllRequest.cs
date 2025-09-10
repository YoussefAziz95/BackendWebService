using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ConsumerDocumentAllRequest(
int ConsumerAccountId,
int PreDocumentId,
bool IsApproved,
string? Comment,
int? FileId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ConsumerDocumentAllResponse>>
{
    public IValidator<ConsumerDocumentAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ConsumerDocumentAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

