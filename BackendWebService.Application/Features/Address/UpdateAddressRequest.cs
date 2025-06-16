namespace Application.Features;

public record UpdateAddressRequest(
int Id,
string FullAddress,
string Street,
string Zone,
string State,
string? City);
