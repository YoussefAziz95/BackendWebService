using Application.Validators.Common;
namespace Application.DTOs.Auths;

public class ResetPasswordRequest : BaseValidationModel<ResetPasswordRequest>
{
    public string Token { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string OldPassword { get; set; }
}
