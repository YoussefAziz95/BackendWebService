using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record LDAPConfigAllRequest(
int ConfigurationId,
string ServerAddress,
string CN,
string DC,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<LDAPConfigAllResponse>>
{
    public IValidator<LDAPConfigAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<LDAPConfigAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

