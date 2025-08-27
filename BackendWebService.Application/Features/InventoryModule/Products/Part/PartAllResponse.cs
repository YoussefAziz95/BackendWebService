using Domain;
using Domain.Enums;

namespace Application.Features;
public record PartAllResponse(
string Name,
string Description,
string Code,
string Image,
string PartNumber,
string Manufacturer,
int ProductId,
Product Product);

