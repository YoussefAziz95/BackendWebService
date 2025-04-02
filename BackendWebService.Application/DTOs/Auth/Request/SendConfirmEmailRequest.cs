using Application.Validators.Common;

namespace Application.DTOs.Auth.Request
{
    public class SendConfirmEmailRequest : BaseValidationModel<SendConfirmEmailRequest>
    {
        public string Email { get; set; }
    }
}