using Domain.Enums;

namespace Application.Features;
public record AttachmentAllResponse(
int EmailId,
int FileId,
int FileFieldValidatorId,
EmailLog Email,
FileLog File,
FileFieldValidator FileFieldValidator);

