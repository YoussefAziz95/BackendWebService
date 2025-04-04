using Application.Validators.Common;

namespace Application.DTOs.Auths;

public class ConfirmOtpRequest : BaseValidationModel<ConfirmOtpRequest>
{
    public string Email { get; set; }
    public string Otp { get; set; }
}
