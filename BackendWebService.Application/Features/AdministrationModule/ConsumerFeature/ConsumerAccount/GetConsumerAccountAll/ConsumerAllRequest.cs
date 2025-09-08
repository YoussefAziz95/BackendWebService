using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ConsumerAllRequest(
int OrganizationId,
decimal? Rating,
string? BankAccount,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ConsumerAllResponse>>
{
    public IValidator<ConsumerAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ConsumerAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

