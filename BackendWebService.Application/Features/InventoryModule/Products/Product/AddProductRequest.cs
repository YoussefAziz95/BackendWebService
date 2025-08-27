using Domain;

namespace Application.Features;
public record AddProductRequest(
string Number,
string Name,
string Description,
string Code,
string PartNumber,
string Manufacturer,
int? FileId,
Category Category,
FileLog? File);