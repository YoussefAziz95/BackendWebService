using Domain;
using Domain.Enums;

namespace Application.Features;
public record SpareAllResponse(
string Number,
bool? IsAvailable,
int? RequiredAmount,
int? AvailableAmount,
int? ProductId,
Product Product);

