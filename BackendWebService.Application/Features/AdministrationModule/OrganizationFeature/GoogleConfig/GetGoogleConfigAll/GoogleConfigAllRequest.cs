using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record GoogleConfigAllRequest(
int ConfigurationId,
string ClientId,
string ClientSecret,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<GoogleConfigAllResponse>>
{
    public IValidator<GoogleConfigAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<GoogleConfigAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

