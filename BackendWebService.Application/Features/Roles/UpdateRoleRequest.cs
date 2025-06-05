using System.Collections.Generic;

namespace Application.Features;

public record UpdateRoleRequest(int Id, string Role, List<UpdateRoleClaimRequest> Claims);