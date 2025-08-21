using Domain;
using Domain.Enums;

namespace Application.Features;
public record GetPaginatedBranchContact(
     int BranchId,
    string Type,
     string Value,
   ContactEnum? ContactType,
    string? WebsiteUrl
    );