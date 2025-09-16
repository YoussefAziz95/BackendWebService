using Application.Profiles;

namespace Application.Features;
public record UpdateAttachmentRequest(
int EmailId,
int FileId,
int FileFieldValidatorId,
UpdateEmailLogRequest Email,
UpdateFileLogRequest File,
UpdateFileFieldValidatorRequest FileFieldValidator):IConvertibleToEntity<Attachment>
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