using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record PreDocumentAllRequest(
string Name,
bool IsRequired,
bool IsMultiple,
bool IsLocal,
int FileTypeId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<PreDocumentAllResponse>>
{
    public IValidator<PreDocumentAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<PreDocumentAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

