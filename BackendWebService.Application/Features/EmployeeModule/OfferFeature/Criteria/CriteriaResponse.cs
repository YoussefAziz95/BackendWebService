namespace Application.Features;
public record CriteriaResponse(
string Term,
bool IsRequired,
int OfferId,
int Weight,
int FileTypeId);
