using Application.Validators.Common;

namespace Application.DTOs.Auths;

public class ConfirmEmailRequest : BaseValidationModel<ConfirmEmailRequest>
{
    public string Token { get; set; }
    public string Email { get; set; }
}
