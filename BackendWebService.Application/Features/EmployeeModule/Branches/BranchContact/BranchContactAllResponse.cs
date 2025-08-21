using Domain;
using Domain.Enums;

namespace Application.Features;
public record BranchContactAllResponse(
   int BranchId,
    string Type,
     string Value,
   ContactEnum? ContactType,
    string? WebsiteUrl
 );
