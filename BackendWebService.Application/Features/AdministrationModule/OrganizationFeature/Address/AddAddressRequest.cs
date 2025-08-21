namespace Application.Features;
public record AddAddressRequest(
 int OrganizationId,
bool IsAdministration,
string FullAddress,
string Street,
string Zone,
string State,
string City
    );