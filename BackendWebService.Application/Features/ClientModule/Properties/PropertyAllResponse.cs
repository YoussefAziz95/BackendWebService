using Domain;
using Domain.Enums;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace Application.Features;
public record PropertyAllResponse(
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
    bool IsDeleted
 );
