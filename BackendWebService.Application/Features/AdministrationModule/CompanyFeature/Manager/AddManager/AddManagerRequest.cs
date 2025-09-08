using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record AddManagerRequest(
int OrganizationId,
string Name,
string Position,
List<AddManagerRequest> Manager) : IConvertibleToEntity<Manager>, IRequest<int>
{
    public IValidator<AddManagerRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddManagerRequest> validator)
    {
        throw new NotImplementedException();
    }

    public Manager ToEntity() => new Manager
    {
        OrganizationId = OrganizationId,
        Name = Name,
        Position = Position
    };
}