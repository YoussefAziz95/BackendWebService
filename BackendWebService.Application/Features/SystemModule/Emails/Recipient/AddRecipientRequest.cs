namespace Application.Features;
public record AddRecipientRequest(
int ReceiverId,
int EmailId,
Actor Reciver,
EmailLog Email);