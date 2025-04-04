using Application.Validators.Common;

namespace Application.DTOs.Auths;

public class LoginRequest : BaseValidationModel<LoginRequest>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
