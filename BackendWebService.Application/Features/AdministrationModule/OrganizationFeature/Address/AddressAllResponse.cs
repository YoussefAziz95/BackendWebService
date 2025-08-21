namespace Application.Features;
public record AddressAllResponse(
 int OrganizationId,
bool IsAdministration,
string FullAddress,
string Street,
string Zone,
string State,
string City
    );
