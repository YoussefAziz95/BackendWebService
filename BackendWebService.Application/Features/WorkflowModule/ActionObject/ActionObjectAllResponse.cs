using Domain.Enums;

namespace Application.Features;
public record ActionObjectAllResponse(
int ActionId,
string ActionType,
int ObjectId,
string ObjectType);

