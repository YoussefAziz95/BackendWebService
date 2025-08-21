using Domain;
using Domain.Enums;

namespace Application.Features;
public record BranchLocationAllResponse(
  int BranchId,
    string? Street,
    string? City,
  string? State,
    string? Country,
   string? PostalCode,
   double Latitude,
   double Longitude,
   string? Notes
 );
