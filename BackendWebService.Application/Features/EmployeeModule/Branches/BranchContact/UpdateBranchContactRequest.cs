using Application.Profiles;
using Domain;
using Domain.Enums;
using Newtonsoft.Json.Linq;

namespace Application.Features;
public record UpdateBranchContactRequest(
int BranchId,
string Type,
string Value,
ContactEnum? ContactType):IConvertibleToEntity<BranchContact>
{
public BranchContact ToEntity() => new BranchContact
{
    BranchId = BranchId,
    Type = Type,
    Value = Value};
}