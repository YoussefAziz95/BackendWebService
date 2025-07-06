namespace Application.Features;
public record ConfirmResetPasswordRequest(string PhoneNumber, string Token, string NewPassword);