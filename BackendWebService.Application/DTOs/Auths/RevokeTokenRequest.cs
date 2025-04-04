using Application.Validators.Common;

namespace Application.DTOs.Auths;

public class RevokeTokenRequest : BaseValidationModel<RevokeTokenRequest>
{
    public string Token { get; set; }
}
