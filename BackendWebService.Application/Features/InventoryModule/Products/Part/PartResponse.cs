using Domain;

namespace Application.Features;
public record PartResponse(
string Name,
string Description,
string Code,
string Image,
string PartNumber,
string Manufacturer,
int ProductId,
Product Product);