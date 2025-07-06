namespace Application.Features;
public record TwoFactorRequest(string Code, bool RememberMe = false, bool RememberClient = false);
