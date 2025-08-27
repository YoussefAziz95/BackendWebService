using Domain.Enums;

namespace Application.Features;
public record UpdateActionObjectRequest(
int ActionId,
string ActionType,
int ObjectId,
string ObjectType);