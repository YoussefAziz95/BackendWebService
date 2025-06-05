namespace Application.Features;

public record UpdateAddressRequest(int Id, string FullAddress, string City, string State, string Country, string? PostalCode);
