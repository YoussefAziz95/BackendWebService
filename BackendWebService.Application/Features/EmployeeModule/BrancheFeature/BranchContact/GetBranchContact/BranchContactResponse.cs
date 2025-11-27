using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record BranchContactResponse(
    int BranchId,
    string Type,
     string Value,
   ContactEnum? ContactType) : IConvertibleFromEntity<BranchContact, BranchContactResponse>, IRequest<int>
{
    public static BranchContactResponse FromEntity(BranchContact BranchContact) =>
    new BranchContactResponse(
    BranchContact.BranchId,
    BranchContact.Type,
    BranchContact.Value,
    BranchContact.ContactType);
}
