using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record BranchContactAllResponse(
int BranchId,
string Type,
string Value,
ContactEnum? ContactType) : IConvertibleFromEntity<BranchContact, BranchContactAllResponse>
{
    public static BranchContactAllResponse FromEntity(BranchContact BranchContact) =>
    new BranchContactAllResponse(
    BranchContact.BranchId,
    BranchContact.Type,
    BranchContact.Value,
    BranchContact.ContactType);
}
