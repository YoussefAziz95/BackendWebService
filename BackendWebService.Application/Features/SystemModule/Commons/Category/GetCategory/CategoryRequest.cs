using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CategoryRequest(
string Name,
int? ParentId,
int? FileId) : IRequest<CategoryResponse>
{
    public IValidator<CategoryRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CategoryRequest> validator)
    {
        throw new NotImplementedException();
    }
}

