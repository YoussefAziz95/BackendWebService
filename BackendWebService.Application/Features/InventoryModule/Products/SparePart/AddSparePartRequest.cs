using Domain;

namespace Application.Features;
public record AddSparePartRequest(
int PartId,
int? SpareId,
Part Part,
Spare? Spare);