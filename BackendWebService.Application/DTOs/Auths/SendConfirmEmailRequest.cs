using Application.Validators.Common;

namespace Application.DTOs.Auths;

public class SendConfirmEmailRequest : BaseValidationModel<SendConfirmEmailRequest>
{
    public string Email { get; set; }
}