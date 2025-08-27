using Domain.Enums;

namespace Application.Features;
public record RecipientAllResponse(
int ReceiverId,
int EmailId,
Actor Reciver,
EmailLog Email);

