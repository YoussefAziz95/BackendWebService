namespace Application.Features;
public record UpdateAddressRequest(
 int OrganizationId,
bool IsAdministration,
string FullAddress,
string Street,
string Zone,
string State,
string City);
