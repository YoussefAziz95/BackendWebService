using Domain;
using Domain.Enums;

namespace Application.Features;
public record SparePartAllResponse(
int PartId,
int? SpareId,
Part Part,
Spare? Spare);

