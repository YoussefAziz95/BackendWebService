using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ConsumerCustomerAllRequest(
int ConsumerId,
int CategoryId,
string? BankAccount,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ConsumerCustomerAllResponse>>
{
    public IValidator<ConsumerCustomerAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ConsumerCustomerAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

