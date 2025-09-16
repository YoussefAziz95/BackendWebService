using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CustomerAllRequest(
int UserId,
RoleEnum Role,
StatusEnum Status,
bool MFAEnabled = false,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<CustomerAllResponse>>, IRequest<int>
{
    public IValidator<CustomerAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CustomerAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

