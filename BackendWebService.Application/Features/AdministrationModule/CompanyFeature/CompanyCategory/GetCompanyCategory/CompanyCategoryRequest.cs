using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CompanyCategoryRequest(
int CompanyId,
int CategoryId) : IRequest<CompanyCategoryResponse>
{
    public IValidator<CompanyCategoryRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CompanyCategoryRequest> validator)
    {
        throw new NotImplementedException();
    }
}

