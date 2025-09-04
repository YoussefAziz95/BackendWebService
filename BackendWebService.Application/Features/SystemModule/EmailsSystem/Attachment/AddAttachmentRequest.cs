using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddAttachmentRequest(
int EmailId,
int FileId,
int FileFieldValidatorId,
AddEmailLogRequest Email,
AddFileLogRequest File,
AddFileFieldValidatorRequest FileFieldValidator):IConvertibleToEntity<Attachment>
{
public Attachment ToEntity() => new Attachment
{
EmailId = EmailId,
FileId = FileId,
FileFieldValidatorId = FileFieldValidatorId,
Email= Email.ToEntity(),
File= File.ToEntity(),
FileFieldValidator = FileFieldValidator.ToEntity()};
}