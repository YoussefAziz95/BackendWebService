using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AttachmentResponse(
int EmailId,
int FileId,
int FileFieldValidatorId,
EmailLogResponse Email,
FileLogResponse File,
FileFieldValidatorResponse FileFieldValidator) : IConvertibleFromEntity<Attachment, AttachmentResponse>
{
    public static AttachmentResponse FromEntity(Attachment Attachment) =>
    new AttachmentResponse(
    Attachment.EmailId,
    Attachment.FileId,
    Attachment.FileFieldValidatorId,
    EmailLogResponse.FromEntity(Attachment.Email),
    FileLogResponse.FromEntity(Attachment.File),
    FileFieldValidatorResponse.FromEntity(Attachment.FileFieldValidator)
    );
}