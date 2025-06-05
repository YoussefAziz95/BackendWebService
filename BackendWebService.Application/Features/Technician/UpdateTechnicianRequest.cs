using Domain.Enums;

namespace Application.Features;

public record UpdateTechnicianRequest(int Id, string FirstName, string LastName, string Email, string PhoneNumber, StatusEnum Status);