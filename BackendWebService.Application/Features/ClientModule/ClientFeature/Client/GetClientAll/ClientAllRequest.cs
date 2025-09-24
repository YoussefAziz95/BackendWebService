using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ClientAllRequest(
int UserId,
 bool MFAEnabled,
 RoleEnum Role,
 StatusEnum Status,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ClientAllResponse>>
{
    public IValidator<ClientAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ClientAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

