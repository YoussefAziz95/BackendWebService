using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record AddBranchLocationRequest(
int BranchId,
string? Street,
string? City,
string? State,
string? Country,
string? PostalCode,
double Latitude,
double Longitude,
string? Notes) : IConvertibleToEntity<BranchLocation>, IRequest<int>
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
