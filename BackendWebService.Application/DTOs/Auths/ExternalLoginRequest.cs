namespace BackendWebService.Application.DTOs.SignIn;

public class ExternalLoginRequest
{
    public string Provider { get; set; } = string.Empty;
    public string ProviderKey { get; set; } = string.Empty;
}
