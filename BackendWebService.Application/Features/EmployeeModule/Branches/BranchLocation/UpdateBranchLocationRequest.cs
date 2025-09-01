using Application.Profiles;
using Domain;
using System.Diagnostics.Metrics;
using System.IO;

namespace Application.Features;
public record UpdateBranchLocationRequest(
int BranchId,
string? Street,
string? City,
string? State,
string? Country,
string? PostalCode,
double Latitude,
double Longitude,
string? Notes):IConvertibleToEntity<BranchLocation>
{
public BranchLocation ToEntity() => new BranchLocation
{
BranchId = BranchId,
Street = Street,
City = City,
State = State,
Country = Country,
PostalCode = PostalCode,
Latitude = Latitude,
Longitude = Longitude,
Notes = Notes
};
}
    