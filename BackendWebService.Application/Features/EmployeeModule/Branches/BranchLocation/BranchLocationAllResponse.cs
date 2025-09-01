using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record BranchLocationAllResponse(
int BranchId,
string? Street,
string? City,
string? State,
string? Country,
string? PostalCode,
double Latitude,
double Longitude,
string? Notes): IConvertibleFromEntity<BranchLocation, BranchLocationAllResponse>        
{
public static BranchLocationAllResponse FromEntity(BranchLocation BranchLocation) =>
new BranchLocationAllResponse(
BranchLocation.BranchId,
BranchLocation.Street,
BranchLocation.City,
BranchLocation.State,
BranchLocation.Country,
BranchLocation.PostalCode,
BranchLocation.Latitude,
BranchLocation.Longitude,
BranchLocation.Notes);
}
