namespace Application.Features;

public record PropertyResponse(int Id, int UserId, string Name, string ContactName, string ContactNumber, string ZoneName, double Latitude, double Longitude, DateTimeOffset CreatedAt);