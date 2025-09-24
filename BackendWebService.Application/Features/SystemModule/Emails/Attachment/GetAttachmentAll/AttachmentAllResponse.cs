using Application.Profiles;

namespace Application.Features;
public record AttachmentAllResponse(
int EmailId,
int FileId,
int FileFieldValidatorId) : IConvertibleFromEntity<Attachment, AttachmentAllResponse>
{
    public static AttachmentAllResponse FromEntity(Attachment Attachment) =>
    new AttachmentAllResponse(
    Attachment.EmailId,
    Attachment.FileId,
    Attachment.FileFieldValidatorId);
}


