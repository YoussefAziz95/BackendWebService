using Application.Profiles;

namespace Application.Features;
public record AttachmentResponse(
int EmailId,
int FileId,
int FileFieldValidatorId,
EmailLogResponse Email,
FileLogResponse File,
FileFieldValidatorResponse FileFieldValidator):IConvertibleFromEntity<Attachment, AttachmentResponse>
{
public static AttachmentResponse FromEntity(Attachment Attachment) =>
new AttachmentResponse(
Attachment.EmailId,
Attachment.FileId,
Attachment.FileFieldValidatorId,
Attachment.Email.ToEntity(),
Attachment.File.ToEntity(),
Attachment.FileFieldValidator.ToEntity()
);
}