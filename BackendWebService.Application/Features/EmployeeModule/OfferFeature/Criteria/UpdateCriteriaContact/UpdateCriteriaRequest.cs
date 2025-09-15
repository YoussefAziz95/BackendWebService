using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateCriteriaRequest(
string Term,
bool IsRequired,
int OfferId,
int Weight,
int FileTypeId) : IConvertibleToEntity<Criteria>, IRequest<int>
{
    public Criteria ToEntity() => new Criteria
    {
        Term = Term,
        IsRequired = IsRequired,
        OfferId = OfferId,
        Weight = Weight,
        FileTypeId = FileTypeId

    };
}
