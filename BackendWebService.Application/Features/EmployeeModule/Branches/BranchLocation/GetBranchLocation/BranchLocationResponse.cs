using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record BranchLocationResponse(
   int BranchId,
    string? Street,
    string? City,
  string? State,
    string? Country,
   string? PostalCode,
   double Latitude,
   double Longitude,
   string? Notes) : IConvertibleFromEntity<BranchLocation, BranchLocationResponse>, IRequest<int>
{
    public static BranchLocationResponse FromEntity(BranchLocation BranchLocation) =>
    new BranchLocationResponse(
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
