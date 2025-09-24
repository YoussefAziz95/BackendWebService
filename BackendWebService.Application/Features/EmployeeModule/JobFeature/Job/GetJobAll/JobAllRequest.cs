using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features; 
public record JobAllRequest(
string Name,
string? Description,
DateTime StartDate,
DateTime EndDate,
DateTime? ExpirationTime,
bool IsVerified,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<JobAllResponse>>
{
    public IValidator<JobAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<JobAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

