using Domain;

namespace Application.Features;

public record GetPaginatedProperty(
    int UserId,
   string Name,
    string? ContactName,
   string ContactNumber,
    int? ZoneId,
   Zone? Zone,
    double Latitude,
    double Longitude,
    DateTimeOffset CreatedAt,
    DateTimeOffset? DeletedAt,
    bool IsDeleted);