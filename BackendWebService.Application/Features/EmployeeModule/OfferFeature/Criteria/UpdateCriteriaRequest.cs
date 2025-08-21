namespace Application.Features;
public record UpdateCriteriaRequest(
string Term,
bool IsRequired,
int OfferId,
int Weight,
int FileTypeId);
