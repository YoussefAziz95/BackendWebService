namespace Application.Features;
public record AttachmentResponse(
int EmailId,
int FileId,
int FileFieldValidatorId,
EmailLog Email,
FileLog File,
FileFieldValidator FileFieldValidator);