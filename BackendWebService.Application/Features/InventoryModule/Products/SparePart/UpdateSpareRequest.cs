using Domain;

namespace Application.Features;
public record UpdateSparePartRequest(
int PartId,
int? SpareId,
Part Part,
Spare? Spare);