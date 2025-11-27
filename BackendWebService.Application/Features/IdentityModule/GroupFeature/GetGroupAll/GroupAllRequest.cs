using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record GroupAllRequest(
string Name,
int? ActorId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<GroupAllResponse>>
{
    public IValidator<GroupAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<GroupAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

