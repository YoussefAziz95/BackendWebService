using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record AdministratorAllRequest(
int UserId,
string Attributes,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<AdministratorAllResponse>>
{
    public IValidator<AdministratorAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AdministratorAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

