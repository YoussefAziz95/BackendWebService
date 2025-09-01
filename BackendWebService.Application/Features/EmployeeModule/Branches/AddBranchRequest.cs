using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddBranchRequest(
string FranchiseName,
string? FranchiseSlogan,
string LogoUrl,
string PhoneNumber,
string? WebsiteUrl):IConvertibleToEntity<Branch>
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