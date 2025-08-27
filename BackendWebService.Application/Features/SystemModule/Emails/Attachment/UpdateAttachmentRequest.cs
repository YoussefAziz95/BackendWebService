namespace Application.Features;
public record UpdateAttachmentRequest(
int EmailId,
int FileId,
int FileFieldValidatorId,
EmailLog Email,
FileLog File,
FileFieldValidator FileFieldValidator);