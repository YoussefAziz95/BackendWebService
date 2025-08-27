using Application.Features;
using Domain;

namespace Application.Features;
public record SpareResponse(
string Number,
bool? IsAvailable,
int? RequiredAmount,
int? AvailableAmount,
int? ProductId,
Product Product);