using Domain.Enums;

namespace Application.Features;

public record ActivateDeactivateOtpRequest(int Id, bool HasOtp);
