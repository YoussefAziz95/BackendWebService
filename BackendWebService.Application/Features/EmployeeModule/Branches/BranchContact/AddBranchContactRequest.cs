using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddBranchContactRequest(
int BranchId,
string Type,
string Value,
ContactEnum ContactType) : IConvertibleToEntity<BranchContact>
{
public BranchContact ToEntity() => new BranchContact
{
BranchId = BranchId,
Type = Type,
Value = Value};
}