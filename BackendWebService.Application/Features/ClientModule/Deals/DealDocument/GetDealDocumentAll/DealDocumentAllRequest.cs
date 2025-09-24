using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record DealDocumentAllRequest(
int? Score,
string? Comment,
string? RichText,
int? StatusId,
int DealId,
int CriteriaId,
int FileId,
int FileFieldValidatorId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<DealDocumentAllResponse>>
{
    public IValidator<DealDocumentAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<DealDocumentAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

