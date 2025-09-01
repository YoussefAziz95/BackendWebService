using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record BranchAllResponse(
string FranchiseName,
string? FranchiseSlogan,
string LogoUrl,
string PhoneNumber,
string? WebsiteUrl):IConvertibleFromEntity<Branch, BranchAllResponse>        
{
public static BranchAllResponse FromEntity(Branch Branch) =>
new BranchAllResponse(
Branch.FranchiseName,
Branch.FranchiseSlogan,
Branch.LogoUrl,
Branch.PhoneNumber,
Branch.WebsiteUrl);
}
