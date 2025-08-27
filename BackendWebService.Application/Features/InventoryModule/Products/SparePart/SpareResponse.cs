using Application.Features;
using Domain;

namespace Application.Features;
public record SparePartResponse(
int PartId,
int? SpareId,
Part Part,
Spare? Spare);