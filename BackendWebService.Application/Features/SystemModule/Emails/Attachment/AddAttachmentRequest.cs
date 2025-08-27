namespace Application.Features;
public record AddAttachmentRequest(
int EmailId,
int FileId,
int FileFieldValidatorId,
EmailLog Email,
FileLog File,
FileFieldValidator FileFieldValidator);