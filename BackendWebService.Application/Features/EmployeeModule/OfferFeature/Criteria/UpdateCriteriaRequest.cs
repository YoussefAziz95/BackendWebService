namespace Application.Features;
public record UpdateCriteriaRequest(
int Id,
string Term,
int FileTypeId,
bool? IsRequired,
int Weight,
int OfferId);
