using Application.Validators.Common;

namespace Application.DTOs.SignIn;

public class LoginRequest : BaseValidationModel<LoginRequest>
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool RememberMe { get; set; } = false;
}
