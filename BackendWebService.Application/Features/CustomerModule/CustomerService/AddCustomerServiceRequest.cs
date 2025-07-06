namespace Application.Features;
public record AddCustomerServiceRequest(
bool IsAdministration,
string FullAddress,
string Street,
string Zone,
string State,
string City);