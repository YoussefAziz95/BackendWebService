namespace Application.Features;

public record UpdatePropertyRequest(int Id, int UserId, string Name, string ContactName, string ContactNumber, int ZoneId, double Latitude, double Longitude);