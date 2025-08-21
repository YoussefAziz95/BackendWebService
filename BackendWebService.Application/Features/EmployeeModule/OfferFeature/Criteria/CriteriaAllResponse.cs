namespace Application.Features;
public record CriteriaAllResponse(
string Term,
bool IsRequired,
int OfferId,
int Weight,
int FileTypeId);
