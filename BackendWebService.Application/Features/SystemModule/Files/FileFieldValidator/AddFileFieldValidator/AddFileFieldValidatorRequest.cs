using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddFileFieldValidatorRequest(
int FileTypeId,
AddFileTypeRequest FileType,
ValidatorEnum Validator) : IConvertibleToEntity<FileFieldValidator>, IRequest<int>
{
    public FileFieldValidator ToEntity() => new FileFieldValidator
    {
        FileTypeId = FileTypeId,
        FileType = FileType.ToEntity(),
        Validator = Validator
    };
}