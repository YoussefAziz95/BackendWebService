using Domain;

namespace Application.Features;
public record UpdateProductRequest(
string Number,
string Name,
string Description,
string Code,
string PartNumber,
string Manufacturer,
int? FileId,
Category Category,
FileLog? File);