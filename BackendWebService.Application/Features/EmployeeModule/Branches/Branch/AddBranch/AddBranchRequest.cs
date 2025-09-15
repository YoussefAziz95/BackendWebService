using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record AddBranchRequest(
string FranchiseName,
string? FranchiseSlogan,
string LogoUrl,
string PhoneNumber,
string? WebsiteUrl) : IConvertibleToEntity<Branch>,IRequest<int>
{
    public Branch ToEntity() => new Branch
    {
        FranchiseName = FranchiseName,
        FranchiseSlogan = FranchiseSlogan,
        LogoUrl = LogoUrl,
        PhoneNumber = PhoneNumber,
        WebsiteUrl = WebsiteUrl
    };
}
