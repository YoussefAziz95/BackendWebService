using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ManagerRequest(
int OrganizationId,
string Name,
string Position) : IRequest<ManagerResponse>
{
    public IValidator<ManagerRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ManagerRequest> validator)
    {
        throw new NotImplementedException();
    }
}

