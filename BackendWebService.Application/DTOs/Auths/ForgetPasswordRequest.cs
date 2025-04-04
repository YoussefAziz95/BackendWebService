using Application.Validators.Common;

namespace Application.DTOs.Auths;

public class ForgetPasswordRequest : BaseValidationModel<ForgetPasswordRequest>
{
    public string Email { get; set; }
}
