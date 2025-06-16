namespace Application.Features;

public record CriteriaResponse(
int Id,
string Term,
int FileTypeId,
bool? IsRequired,
int Weight,
int OfferId);
