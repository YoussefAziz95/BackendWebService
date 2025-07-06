namespace Application.Features;

public record AddPropertyRequest(int UserId, string Name, string ContactName, string ContactNumber, int ZoneId, double Latitude, double Longitude);