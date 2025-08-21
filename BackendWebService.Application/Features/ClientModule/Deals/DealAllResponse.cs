using Domain;
using Domain.Enums;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace Application.Features;
public record DealAllResponse(
int OrganizationId,
int OfferId,
int UserId,
int CompanyVendorId,
int Vat,
int Quantity,
int Discount,
int StatusId,
decimal? TotalPrice,
decimal? FinalPrice
 );
