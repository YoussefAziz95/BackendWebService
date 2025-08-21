using Domain;

namespace Application.Features;
public record AddBranchLocationRequest(
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