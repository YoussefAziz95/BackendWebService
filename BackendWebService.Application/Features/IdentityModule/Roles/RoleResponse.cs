﻿namespace Application.Features;
public record RoleResponse(int RoleId, string Name, List<ClaimResponse>? Claims);