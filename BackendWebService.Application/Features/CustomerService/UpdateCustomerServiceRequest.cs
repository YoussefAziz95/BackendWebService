namespace Application.Features;

public record UpdateCustomerServiceRequest(
int Id,
string FullAddress,
string Street,
string Zone,
string State,
string? City);
