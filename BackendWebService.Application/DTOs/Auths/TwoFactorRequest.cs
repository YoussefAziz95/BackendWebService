namespace BackendWebService.Application.DTOs.SignIn;

public class TwoFactorRequest
{
    public string Code { get; set; } = string.Empty;
    public bool RememberMe { get; set; } = false;
    public bool RememberClient { get; set; } = false;
}
