using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record MicrosoftConfigAllRequest(
int ConfigurationId,
 string ClientId,
 string TenantId,
string Audience,
string Instance,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<MicrosoftConfigAllResponse>>
{
    public IValidator<MicrosoftConfigAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<MicrosoftConfigAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

