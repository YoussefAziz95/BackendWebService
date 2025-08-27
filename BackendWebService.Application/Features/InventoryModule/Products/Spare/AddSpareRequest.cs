using Domain;

namespace Application.Features;
public record AddSpareRequest(
string Number,
bool? IsAvailable,
int? RequiredAmount,
int? AvailableAmount,
int? ProductId,
Product Product);