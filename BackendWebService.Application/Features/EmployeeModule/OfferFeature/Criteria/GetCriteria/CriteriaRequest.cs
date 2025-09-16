using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CriteriaRequest(
string Term,
bool IsRequired,
int OfferId,
int Weight,
int FileTypeId) : IRequest<CriteriaResponse>
{
public IValidator<CriteriaRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CriteriaRequest> validator)
{
throw new NotImplementedException();
}
}

