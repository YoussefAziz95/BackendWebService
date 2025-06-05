namespace Application.Features;

public record AddTechnicianRequest(string FirstName, string LastName, string Email, string Password, string PhoneNumber, bool MFAEnabled = false);