﻿namespace Application.Features;

public record GetPaginatedWorkflowAction(int Id, int CaseId, string CompanyVendorName, string RequesterName, string AssignedOnType, string AssignedOnName, string CaseName, string? CaseType, string? ActionType, string? ActionName);