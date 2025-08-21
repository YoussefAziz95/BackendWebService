using Domain;
using Domain.Enums;

namespace Application.Features;
public record BranchesAllResponse(
string FranchiseName,
    string? FranchiseSlogan,
     string LogoUrl,
   string PhoneNumber,
    string? WebsiteUrl
 );
