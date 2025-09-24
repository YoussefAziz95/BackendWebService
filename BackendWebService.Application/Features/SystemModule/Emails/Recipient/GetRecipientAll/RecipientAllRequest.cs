using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record RecipientAllRequest(
int ReceiverId,
int EmailId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<RecipientAllResponse>>
{
    public IValidator<RecipientAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<RecipientAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

