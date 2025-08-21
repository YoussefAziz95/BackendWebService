namespace Application.Features;
public record AddCriteriaRequest(
string Term,
bool IsRequired,
int OfferId,
int Weight,
int FileTypeId);
