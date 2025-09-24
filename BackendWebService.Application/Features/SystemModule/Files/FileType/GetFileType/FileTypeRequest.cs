using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record FileTypeRequest(
FileTypeEnum Type,
string Extentions) : IRequest<FileTypeResponse>
{
    public IValidator<FileTypeRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<FileTypeRequest> validator)
    {
        throw new NotImplementedException();
    }
}

