using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record FileFieldValidatorRequest(
int FileTypeId,
ValidatorEnum Validator) : IRequest<FileFieldValidatorResponse>
{
    public IValidator<FileFieldValidatorRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<FileFieldValidatorRequest> validator)
    {
        throw new NotImplementedException();
    }
}

