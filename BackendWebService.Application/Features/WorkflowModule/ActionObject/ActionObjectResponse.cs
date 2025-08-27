using Domain.Enums;

namespace Application.Features;
public record ActionObjectResponse(
int ActionId,
string ActionType,
int ObjectId,
string ObjectType);