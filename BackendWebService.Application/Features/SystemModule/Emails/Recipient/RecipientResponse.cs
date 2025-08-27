namespace Application.Features;
public record RecipientResponse(
int ReceiverId,
int EmailId,
Actor Reciver,
EmailLog Email);