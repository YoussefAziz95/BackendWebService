using Application.Validators.Common;

namespace Application.DTOs.Users;

public class ChangePasswordRequest : BaseValidationModel<ChangePasswordRequest>
{
    public required string OldPassword { get; set; }
    public required string NewPassword { get; set; }
}
