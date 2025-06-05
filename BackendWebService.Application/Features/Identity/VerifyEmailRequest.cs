namespace Application.Features;

public record VerifyEmailRequest(string PhoneNumber, string Token);