using Application.Profiles;
using Domain;

namespace Application.Features;
public record CriteriaResponse(
string Term,
bool IsRequired,
int OfferId,
int Weight,
int FileTypeId) : IConvertibleFromEntity<Criteria, CriteriaResponse>
{
public static CriteriaResponse FromEntity(Criteria Criteria) =>
new CriteriaResponse(
Criteria.Term,
Criteria.IsRequired,
Criteria.OfferId,
Criteria.Weight,
Criteria.FileTypeId);
}
