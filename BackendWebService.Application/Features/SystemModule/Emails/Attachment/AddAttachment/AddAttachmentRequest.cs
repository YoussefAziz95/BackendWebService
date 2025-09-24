using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddAttachmentRequest(
int EmailId,
int FileId,
int FileFieldValidatorId,
AddEmailLogRequest Email,
AddFileLogRequest File,
AddFileFieldValidatorRequest FileFieldValidator) : IConvertibleToEntity<Attachment>, IRequest<int>
{
    public Attachment ToEntity() => new Attachment
    {
        EmailId = EmailId,
        FileId = FileId,
        FileFieldValidatorId = FileFieldValidatorId,
        Email = Email.ToEntity(),
        File = File.ToEntity(),
        FileFieldValidator = FileFieldValidator.ToEntity()
    };
}