namespace Application.Features;
public record UpdateRecipientRequest(
int ReceiverId,
int EmailId,
Actor Reciver,
EmailLog Email);