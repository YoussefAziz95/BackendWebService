namespace Application.Features;
public record MfaVerifyRequest(string PhoneNumber, string Code);