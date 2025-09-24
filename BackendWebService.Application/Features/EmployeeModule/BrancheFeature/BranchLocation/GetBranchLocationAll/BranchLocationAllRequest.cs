using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record BranchLocationAllRequest(
 int BranchId,
string? Street,
string? City,
string? State,
string? Country,
string? PostalCode,
double Latitude,
double Longitude,
string? Notes,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<BranchLocationAllResponse>>
{
    public IValidator<BranchLocationAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<BranchLocationAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

