using Domain.Enums;

namespace Application.Features;

public record ChangePasswordRequest(string OldPassword, string NewPassword);
