using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ActorAllRequest(
int ActorId,
string ActorType,
int OwnerId,
string OwnerType,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ActorAllResponse>>
{
    public IValidator<ActorAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ActorAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

