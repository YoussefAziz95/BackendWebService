using Domain;

namespace Application.Features;
public record CategoryAllResponse(
string Name,
int? ParentId,
int? FileId,
FileLog? File,
Category? ParentCategory);
