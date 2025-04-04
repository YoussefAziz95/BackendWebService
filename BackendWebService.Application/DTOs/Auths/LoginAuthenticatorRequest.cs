using Application.Validators.Common;

namespace Application.DTOs.Auths;

public class LoginAuthenticatorRequest : BaseValidationModel<LoginAuthenticatorRequest>
{
    public string ClientId { get; set; }
    public string AccessToken { get; set; }
}
