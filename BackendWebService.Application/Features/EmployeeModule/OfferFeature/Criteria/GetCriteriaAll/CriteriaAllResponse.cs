using Application.Profiles;
using Domain;

namespace Application.Features;
public record CriteriaAllResponse(
string Term,
bool IsRequired,
int OfferId,
int Weight,
int FileTypeId) : IConvertibleFromEntity<Criteria, CriteriaAllResponse>
{
    public static CriteriaAllResponse FromEntity(Criteria Criteria) =>
    new CriteriaAllResponse(
    Criteria.Term,
    Criteria.IsRequired,
    Criteria.OfferId,
    Criteria.Weight,
    Criteria.FileTypeId);
}
