namespace Application.Features;

public record AddAddressRequest(
bool IsAdministration,
string FullAddress,
string Street,
string Zone,
string State,
string City);