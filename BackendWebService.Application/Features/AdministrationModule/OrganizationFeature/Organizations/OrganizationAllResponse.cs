using Domain;
using Domain.Enums;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace Application.Features;
public record OrganizationAllResponse(
   string Country,
    string City,
    string StreetAddress,
    OrganizationEnum Type,
    string FaxNo,
    string Phone,
    string Email,
    string TaxNo,
    int FileId
 );
