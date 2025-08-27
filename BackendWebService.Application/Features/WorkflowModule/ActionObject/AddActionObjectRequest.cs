using Domain.Enums;

namespace Application.Features;
public record AddActionObjectRequest(
int ActionId,
string ActionType,
int ObjectId,
string ObjectType);