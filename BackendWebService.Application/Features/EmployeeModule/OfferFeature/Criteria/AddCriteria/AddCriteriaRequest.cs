using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using Org.BouncyCastle.Crypto;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddCriteriaRequest(
string Term,
bool IsRequired,
int OfferId,
int Weight,
int FileTypeId) : IConvertibleToEntity<Criteria>, IRequest<int>
{
    public Criteria ToEntity() => new Criteria
    {
        Term = Term,
        IsRequired = IsRequired,
        OfferId = OfferId,
        Weight = Weight,
        FileTypeId = FileTypeId
    };

  
    

    public IValidator<AddCriteriaRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddCriteriaRequest> validator)
    {
        validator.RuleFor(c => c.Term).NotEmpty().WithMessage("Please enter a term");
        validator.RuleFor(c => c.Weight).InclusiveBetween(1, 100).WithMessage("Weight must be between 1 and 100");
        return validator;
    }
}
