using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record SupplierDocumentAllRequest(
int SupplierAccountId,
int PreDocumentId,
int FileId,
DateTime? ApprovedDate,
bool IsApproved,
string? Comment,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<SupplierDocumentAllResponse>>
{
    public IValidator<SupplierDocumentAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<SupplierDocumentAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

