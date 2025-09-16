using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ConsumerAccountAllRequest(
int CompanyId,
int ConsumerId,
bool IsApproved,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ConsumerAccountAllResponse>>
{
    public IValidator<ConsumerAccountAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ConsumerAccountAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

