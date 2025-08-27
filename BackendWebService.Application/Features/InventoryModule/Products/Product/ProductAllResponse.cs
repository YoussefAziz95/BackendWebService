using Domain;
using Domain.Enums;

namespace Application.Features;
public record ProductAllResponse(
string Number,
string Name,
string Description,
string Code,
string PartNumber,
string Manufacturer,
int? FileId,
Category Category,
FileLog? File);

