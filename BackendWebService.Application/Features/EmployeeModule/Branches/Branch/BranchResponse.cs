using Application.Profiles;
using Domain;

namespace Application.Features;
public record BranchResponse(
string FranchiseName,
string? FranchiseSlogan,
string LogoUrl,
string PhoneNumber,
string? WebsiteUrl):IConvertibleFromEntity<Branch, BranchResponse>        
{
public static BranchResponse FromEntity(Branch Branch) =>
new BranchResponse(
Branch.FranchiseName,
Branch.FranchiseSlogan,
Branch.LogoUrl,
Branch.PhoneNumber,
Branch.WebsiteUrl);
}